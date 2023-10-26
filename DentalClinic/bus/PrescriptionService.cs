using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class PrescriptionService
    {
        public List<Prescription> GetAll()
        {
            DentalModel model = new DentalModel();
            return model.Prescriptions.ToList();
        }
        public Prescription GetPrescriptionsID(string id)
        {
            DentalModel model = new DentalModel();
            return model.Prescriptions.FirstOrDefault(i=>i.ID.ToString() == id);
        }
        public List<Prescription> GetIDByPatientID(int id)
        {
            DentalModel model = new DentalModel();
            return model.Prescriptions.Where(p=>p.Patient_ID == id).ToList();
        }
        public List<int?> GetQuantitiesByIds(List<int?> ids)
        {
            using (var model = new DentalModel())
            {
                return ids.Select(id =>
                {
                    var info = model.Prescriptions.FirstOrDefault(i => i.ID == id);
                    return info?.Quantity;
                }).ToList();
            }
        }
        public List<string> GetUnit(List<int?> unit)
        {
            using (var model = new DentalModel()) 
            {
                return unit.Select(u=>
                {
                    var unitName = model.Prescriptions.FirstOrDefault(i => i.ID == u);
                    return unitName.Medicine.Unit;
                }).ToList();
            }
        }
        public List<decimal> GetTotal(List<int?> total)
        {
            using (var model = new DentalModel())
            {
                return total.Select(u =>
                {
                    var totalAmount = model.Prescriptions.FirstOrDefault(i => i.ID == u);
                    return totalAmount.TotalAmount;
                }).ToList();
            }
        }
        public string GetTotal(int id) 
        {
            using (var context = new DentalModel())
            {
                var totalAmount = context.Prescriptions.FirstOrDefault(p => p.ID == id).TotalAmount;
                return totalAmount.ToString();
            }
        }
        public List<decimal?> GetPrice(List<int?> price)
        {
            using (var model = new DentalModel())
            {
                return price.Select(u =>
                {
                    var unitName = model.Prescriptions.FirstOrDefault(i => i.ID ==u);
                    return unitName.Medicine.UnitPrice;
                }).ToList();

            }
        }
        public List<string> GetDosage(List<int?> dosage)
        {
            using (var model = new DentalModel())
            {
                return dosage.Select(u =>
                {
                    var unitName = model.Prescriptions.FirstOrDefault(i => i.ID == u);
                    return unitName.Medicine.Dosage;
                }).ToList();

            }
        }

        public string GetMedicineName(int id)
        {
            DentalModel model = new DentalModel();
            var medicinename = model.Prescriptions.Where(p => p.ID == id)
                                                  .Select(p => p.Medicine.MedicineName)
                                                  .FirstOrDefault();
            return medicinename;
        }

        public DateTime GetMedicineInvoiceDate(int id)
        {
            DentalModel model = new DentalModel();
            var date = model.MedicineInvoiceDetails.Where(p => p.Prescription_ID == id)
                                                   .Select(p=>p.MedicineInvoice.Date)
                                                   .FirstOrDefault() ;
            return (DateTime)date;
        }

        public List<Prescription> GetAllBetweenDates(DateTime startDate, DateTime endDate)
        {
            DentalModel model = new DentalModel() ;
            return model.Prescriptions.AsEnumerable().Where(t=>GetMedicineInvoiceDate(t.ID) >= startDate && GetMedicineInvoiceDate(t.ID)<=endDate).ToList();
        }
        public void InsertNew(Prescription prescription)
        {
            using (DentalModel model = new DentalModel())
            {
                model.Prescriptions.Add(prescription);
                model.SaveChanges();
            }
        }

        public int GetMedicineQuantity(int id, DateTime startDate, DateTime endDate)
        {
            DentalModel model = new DentalModel();
            var totalQuantity = model.Prescriptions.AsEnumerable().Where(x => x.MedicineID == id && GetMedicineInvoiceDate(x.ID) >= startDate && GetMedicineInvoiceDate(x.ID) <= endDate)
                                                   .Sum(x => x.Quantity);
            return totalQuantity;
        }
        public List<string> GetMedName(List<int?> ids)
        {
            using (var model = new DentalModel())
            {
                return ids.Select(id =>
                {
                    var info = model.Prescriptions.FirstOrDefault(i => i.ID == id);
                    return info?.Medicine.MedicineName;
                }).ToList();
            }
        }
        public List<int?> GetPrescriptionIdsByInvoiceId(int invoiceId)
        {
            using (var model = new DentalModel())
            {
                return model.MedicineInvoiceDetails
                    .Where(detail => detail.InvoiceID == invoiceId)
                    .Select(detail => detail.Prescription_ID)
                    .ToList();
            }
        }
    }
}
