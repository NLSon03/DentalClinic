using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bus
{
    public class InventoryService
    {
        public List<Inventory> GetAll()
        {
            DentalModel model = new DentalModel();
            var slnhap = model.DentalToolTransactionsDetails.Where(x => x.DentalToolTransaction.TransactionType == false)
                                                            .GroupBy(x => x.ToolID)
                                                            .ToDictionary(group => group.Key, group => group.Sum(x => x.Quantity));
            var slxuat = model.DentalToolTransactionsDetails.Where(x => x.DentalToolTransaction.TransactionType == true)
                                                            .GroupBy(x => x.ToolID)
                                                            .ToDictionary(group => group.Key, group => group.Sum(x => x.Quantity));
            var sltieuhao = model.ClinicalInformations
                    .Join(model.ConsumableTools,
                          ci => ci.Treatment_ID,
                          ct => ct.TreatmentID,
                          (ci, ct) => new { ci, ct })
                    .Join(model.Treatments,
                          a => a.ci.Treatment_ID,
                          t => t.ID,
                          (a, t) => new { a, t })
                    .GroupBy(x => new { x.a.ct.ToolID })
                    .ToDictionary(group => group.Key.ToolID, group => group.Sum(x => x.a.ci.Quantity * x.a.ct.Quantity));
            var slThuocBan = model.Medicines.Join(model.Prescriptions,  
                                              m => m.MedicineID,
                                              p => p.MedicineID,
                                              (m, p) => new { m, p }
                                             ).GroupBy(x => x.m.MedicineID)
                                              .ToDictionary(group => group.Key, group => group.Sum(x => x.p.Quantity));
            var list = model.DentalTools.ToList().Select(x =>
            {
                var quantityPurchased = slnhap.ContainsKey(x.ToolID) ? slnhap[x.ToolID] : 0;
                var quantitySold = slxuat.ContainsKey(x.ToolID) ? slxuat[x.ToolID] : 0;
                var consumedQuantity = 0;
                DateTime? lastUpdateDate = null;
                var dates = new List<DateTime?>();
                if (x.Type == false)
                {
                    consumedQuantity = sltieuhao.ContainsKey(x.ToolID) ? sltieuhao[x.ToolID].GetValueOrDefault() : 0;
                    var ngayNhapXuat = GetNgayNhapXuat(x.ToolID,null,null);
                    var ngayTieuHao = GetNgayTieuHao(x.ToolID, null, null);
                    dates.Add(ngayNhapXuat);
                    dates.Add(ngayTieuHao);

                }
                else if (x.Type == true)
                {
                    consumedQuantity += slThuocBan.ContainsKey(x.ToolID) ? slThuocBan[x.ToolID]  : 0;
                    var ngayNhapXuat = GetNgayNhapXuat(x.ToolID, null, null);
                    var ngayBanThuoc = GetNgayBanThuoc(x.ToolID, null, null);
                    dates.Add(ngayNhapXuat);
                    dates.Add(ngayBanThuoc);
                }
                lastUpdateDate = dates.Max();
                return new Inventory
                {
                    ToolName = x.ToolName,
                    QuantityPurchased = quantityPurchased,
                    QuantitySold = quantitySold,
                    ConsumedQuantity = consumedQuantity,
                    RemainingQuantity = x.Quantity,
                    LastUpdateDate = lastUpdateDate
                };
            }).ToList();
            return list;
        }




        public List<Inventory> GetAllBetweenDates(DateTime startDate, DateTime endDate)
        {
            DentalModel model = new DentalModel();
            var slnhap = model.DentalToolTransactionsDetails.Where(x => x.DentalToolTransaction.TransactionType == false && x.DentalToolTransaction.TransactionDate >= startDate && x.DentalToolTransaction.TransactionDate <= endDate)
                                                            .GroupBy(x => x.ToolID)
                                                            .ToDictionary(group => group.Key, group => group.Sum(x => x.Quantity));
            var slxuat = model.DentalToolTransactionsDetails.Where(x => x.DentalToolTransaction.TransactionType == true && x.DentalToolTransaction.TransactionDate >= startDate && x.DentalToolTransaction.TransactionDate <= endDate)
                                                            .GroupBy(x => x.ToolID)
                                                            .ToDictionary(group => group.Key, group => group.Sum(x => x.Quantity));
            var sltieuhao = (from CT in model.ConsumableTools
                            join CI in model.ClinicalInformations on CT.TreatmentID equals CI.Treatment_ID
                            join TID in model.TreatmentInvoiceDetails on CI.ID equals TID.ClinicInfor_ID
                            join TI in model.TreatmentInvoices on TID.InvoiceID equals TI.ID
                            join T in model.Treatments on CT.TreatmentID equals T.Treatment1
                            where TI.Date >= startDate && TI.Date <= endDate
                            group new { CT.ToolID, Quantity = CT.Quantity * CI.Quantity } by CT.ToolID into grouped
                            select new
                            {
                                ToolID = grouped.Key,
                                TotalQuantity = grouped.Sum(x => x.Quantity)
                            }).ToDictionary(item => item.ToolID, item => item.TotalQuantity);
            var slThuocBan = (from P in model.Prescriptions
                              join M in model.Medicines on P.MedicineID equals M.MedicineID
                              join MID in model.MedicineInvoiceDetails on P.ID equals MID.Prescription_ID
                              join MI in model.MedicineInvoices on MID.InvoiceID equals MI.ID
                              where MI.Date >= startDate && MI.Date <= endDate
                              group P by P.MedicineID into grouped
                              select new
                              {
                                  MedicineID = grouped.Key,
                                  TotalQuantity = grouped.Sum(x => x.Quantity)
                              }).ToDictionary(item => item.MedicineID, item => item.TotalQuantity);
            var list = model.DentalTools.ToList().Select(x =>
            {
                var quantityPurchased = slnhap.ContainsKey(x.ToolID) ? slnhap[x.ToolID] : 0;
                var quantitySold = slxuat.ContainsKey(x.ToolID) ? slxuat[x.ToolID] : 0;
                var consumedQuantity = 0;

                DateTime? lastUpdateDate = null;
                var dates = new List<DateTime?>();

                if (x.Type == false)
                {
                    consumedQuantity = sltieuhao.ContainsKey(x.ToolID) ? sltieuhao[x.ToolID].GetValueOrDefault() : 0;
                    var ngayNhapXuat = GetNgayNhapXuat(x.ToolID, startDate, endDate);
                    var ngayTieuHao = GetNgayTieuHao(x.ToolID, startDate, endDate);
                    dates.Add(ngayNhapXuat);
                    dates.Add(ngayTieuHao);
                }
                else if (x.Type == true)
                {
                    consumedQuantity += slThuocBan.ContainsKey(x.ToolID) ? slThuocBan[x.ToolID]  : 0;
                    var ngayNhapXuat = GetNgayNhapXuat(x.ToolID, startDate, endDate);
                    var ngayBanThuoc = GetNgayBanThuoc(x.ToolID, startDate, endDate);
                    dates.Add(ngayNhapXuat);
                    dates.Add(ngayBanThuoc);
                }
                lastUpdateDate = dates.Max();
                int slton = x.Quantity - quantityPurchased + quantitySold + consumedQuantity;
                return new Inventory
                {
                    ToolName = x.ToolName,
                    QuantityPurchased = quantityPurchased,
                    QuantitySold = quantitySold,
                    ConsumedQuantity = consumedQuantity,
                    RemainingQuantity = slton,
                    LastUpdateDate = lastUpdateDate
                };
            }).ToList();
            return list;
        }

        private DateTime? GetNgayBanThuoc(int toolID, DateTime? startDate, DateTime? endDate)
        {
            DentalModel model = new DentalModel();
            if (startDate == null && endDate == null)
            {
                startDate = DateTime.MinValue; endDate = DateTime.MaxValue;
            }
            var result = model.Prescriptions
            .Where(p => p.MedicineID == toolID)
            .Join(model.MedicineInvoiceDetails,
                  p => p.ID,
                  mid => mid.Prescription_ID,
                  (p, mid) => new { p, mid })
            .Join(model.MedicineInvoices,
                  a => a.mid.InvoiceID,
                  mi => mi.ID,
                  (a, mi) => new { a, mi })
            .Where(x => x.mi.Date >= startDate && x.mi.Date <= endDate)
            .OrderByDescending(x => x.mi.Date)
            .Select(x => new { x.a.p.MedicineID, x.mi.Date })
            .FirstOrDefault();
            return result?.Date;
        }

        private DateTime? GetNgayTieuHao(int toolID, DateTime? startDate, DateTime? endDate)
        {
                DentalModel model = new DentalModel();
            if (startDate == null && endDate == null)
            {
                startDate = DateTime.MinValue; endDate = DateTime.MaxValue;
            }
            var result = (from CT in model.ConsumableTools
                              join T in model.Treatments on CT.TreatmentID equals T.Treatment1
                              join CI in model.ClinicalInformations on T.ID equals CI.Treatment_ID
                              join TID in model.TreatmentInvoiceDetails on CI.ID equals TID.ClinicInfor_ID
                              join TI in model.TreatmentInvoices on TID.InvoiceID equals TI.ID
                              where CT.ToolID == toolID && TI.Date >= startDate && TI.Date <= endDate
                              orderby TI.Date descending
                              select new { CT.ToolID, TI.Date }).FirstOrDefault();
                return result?.Date;
        }

        private DateTime? GetNgayNhapXuat(int toolID, DateTime? startDate, DateTime? endDate)
        {
            DentalModel model = new DentalModel();
            if (startDate == null && endDate == null)
            {
                startDate = DateTime.MinValue; endDate = DateTime.MaxValue;
            }
            return model.DentalToolTransactionsDetails.Where(x => x.ToolID == toolID && x.DentalToolTransaction.TransactionDate>=startDate && x.DentalToolTransaction.TransactionDate <= endDate)
                                                      .OrderByDescending(x => x.DentalToolTransaction.TransactionDate)
                                                      .Select(x => x.DentalToolTransaction.TransactionDate).FirstOrDefault();
        }
    }
}
