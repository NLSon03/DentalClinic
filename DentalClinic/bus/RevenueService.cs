using dal.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class RevenueService
    {
        public List<Revenue> GetAll()
        {
            DentalModel model = new DentalModel();
            //Lấy bảng hóa đơn điều trị
            var treatmentInvoices = model.TreatmentInvoices.Select(p => new Revenue { Ngay = (DateTime)p.Date, TienThu = (decimal)p.TotalAmount, TienChi = 0 });
            //Lấy bảng hóa đơn thuốc 
            var medicineInvoices = model.MedicineInvoices.Select(a => new Revenue { Ngay = (DateTime)a.Date, TienThu = (decimal)a.TotalAmount, TienChi = 0 });
            //Lấy bảng nhập xuất
            var dentalToolTransactions = model.DentalToolTransactions.Select(b => new Revenue
            {
                Ngay = (DateTime)b.TransactionDate,
                TienThu = (b.TransactionType == true) ? (decimal)b.TotalAmount : 0,
                TienChi = (b.TransactionType == true) ? 0 : (decimal)b.TotalAmount
            });
            //Gộp 3 bảng
            var combinelist = treatmentInvoices.Union(medicineInvoices).Union(dentalToolTransactions);
            //Group lại theo ngày
            var grouped = combinelist.AsEnumerable().GroupBy(r => r.Ngay).Select(g => new Revenue
            {
                Ngay = g.Key,
                TienChi = g.Sum(r => r.TienChi),
                TienThu = g.Sum(r => r.TienThu)
            }).ToList();
            return grouped;
        }

        public List<Revenue> GetAllBetweenDates(DateTime startDate, DateTime endDate)
        {
            DentalModel model = new DentalModel();
            var treatmentInvoices = model.TreatmentInvoices
                                     .Where(p => p.Date >= startDate && p.Date <= endDate)
                                     .Select(p => new Revenue
                                     {
                                         Ngay = (DateTime)p.Date,
                                         TienThu = (decimal)p.TotalAmount,
                                         TienChi = 0
                                     });

            var medicineInvoices = model.MedicineInvoices
                                        .Where(a => a.Date >= startDate && a.Date <= endDate)
                                        .Select(a => new Revenue
                                        {
                                            Ngay = (DateTime)a.Date,
                                            TienThu = (decimal)a.TotalAmount,
                                            TienChi = 0
                                        });

            var dentalToolTransactions = model.DentalToolTransactions
                                              .Where(b => b.TransactionDate >= startDate && b.TransactionDate <= endDate)
                                              .Select(b => new Revenue
                                              {
                                                  Ngay = (DateTime)b.TransactionDate,
                                                  TienThu = (b.TransactionType == true) ? (decimal)b.TotalAmount : 0,
                                                  TienChi = (b.TransactionType == true) ? 0 : (decimal)b.TotalAmount
                                              });
            var combinedList = treatmentInvoices.Union(medicineInvoices).Union(dentalToolTransactions);
            var grouped = combinedList.AsEnumerable().GroupBy(r => r.Ngay).Select(g => new Revenue
            {
                Ngay = g.Key,
                TienChi = g.Sum(r => r.TienChi),
                TienThu = g.Sum(r => r.TienThu)
            }).ToList();
            return grouped;
        }
    }
}