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
    }
}
