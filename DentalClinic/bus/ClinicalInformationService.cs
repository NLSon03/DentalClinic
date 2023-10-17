using dal.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class ClinicalInformationService
    {
        public List<ClinicalInformation> GetAll()
        {
            DentalModel model = new DentalModel();
            return model.ClinicalInformations.ToList();
        }

        public List<ClinicalInformation> GetByID(string ID)
        {
            DentalModel model = new DentalModel();
            return model.ClinicalInformations.Where(p => p.Patient_ID.ToString() == ID).ToList();
        }

        public string GetTreatmentName(int ID)
        {
            DentalModel model = new DentalModel();
            var treatmentName = model.ClinicalInformations
                                  .Where(t => t.ID == ID)
                                  .Select(t => t.Treatment.TreatmentName.Name)
                                  .FirstOrDefault();
            return treatmentName;
        }

        public string GetTreatmentMethodName(int ID)
        {
            DentalModel model = new DentalModel();
            var treatmentMethodName = model.ClinicalInformations.Where(t => t.ID == ID)
                                                                .Select(t => t.Treatment.TreatmentMethodName.Name)
                                                                .FirstOrDefault();
            return treatmentMethodName;
        }

        public DateTime GetTreatmentInvoiceDate(int ID)
        {
            DentalModel model = new DentalModel();
            var treatmentInvoiceDate = model.TreatmentInvoiceDetails
                                           .Where(t => t.ClinicInfor_ID == ID)
                                           .Select(t => t.TreatmentInvoice.Date)
                                           .FirstOrDefault();

            return (DateTime)treatmentInvoiceDate;
        }

        public List<ClinicalInformation> GetAllBetweenDates(DateTime date1, DateTime date2)
        {
            DentalModel model = new DentalModel();
            return model.ClinicalInformations.AsEnumerable()
                                .Where(t => GetTreatmentInvoiceDate(t.ID) >= date1 && GetTreatmentInvoiceDate(t.ID) <= date2)
                                .ToList();
        }
    }
}
