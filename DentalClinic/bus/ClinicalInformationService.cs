using dal.Entities;
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

        public ClinicalInformation GetByClinicID(string id)
        {
            DentalModel model = new DentalModel();
            return model.ClinicalInformations.FirstOrDefault(p => p.ID.ToString() == id);
        }

        public List<ClinicalInformation> GetByID(string ID)
        {
            DentalModel model = new DentalModel();
            return model.ClinicalInformations.Where(p => p.Patient_ID.ToString() == ID).ToList();
        }

        public void Insert(ClinicalInformation clinicalInformation)
        {
            var model = new DentalModel();
            model.ClinicalInformations.Add(clinicalInformation);
            model.SaveChanges();
        }

        public void Insert(int patientID, int diagID, int? treatID, int quantity, decimal? totalAmount)
        {
            var model = new DentalModel();
            var clinicInf = new ClinicalInformation
            {
                Patient_ID = patientID,
                Diagnosis_ID = diagID,
                Treatment_ID = treatID,
                Quantity = quantity,
                TotalAmount = totalAmount
            };
            model.ClinicalInformations.Add(clinicInf);
            model.SaveChanges();
        }

        public void Update(ClinicalInformation clinicalInformation)
        {
            var model = new DentalModel();
            var clinicInfor = model.ClinicalInformations.Find(clinicalInformation.ID);
            if (clinicInfor != null)
            {
                clinicInfor.Diagnosis_ID = clinicalInformation.Diagnosis_ID;
                clinicInfor.Treatment_ID = clinicalInformation.Treatment_ID;
                clinicInfor.Quantity = clinicalInformation.Quantity;
                clinicInfor.TotalAmount = clinicalInformation.TotalAmount;
                model.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            var model = new DentalModel();
            var deleteItem = model.ClinicalInformations.FirstOrDefault(p => p.ID.ToString() == id);
            if (deleteItem != null)
            {
                var diagnosis = model.Diagnosis.FirstOrDefault(p => p.ID == deleteItem.Diagnosis_ID);
                model.Diagnosis.Remove(diagnosis);
                model.ClinicalInformations.Remove(deleteItem);
            }
            model.SaveChanges();
        }

        public List<string> GetTreatmentNamesByIds(List<int?> ids)
        {
            using (var model = new DentalModel())
            {
                return ids.Select(id =>
                {
                    var info = model.ClinicalInformations.FirstOrDefault(i => i.ID == id);
                    return $"{info?.Treatment.TreatmentName.Name} - {info?.Treatment.TreatmentMethodName.Name}";
                }).ToList();
            }
        }

        public List<int?> GetQuantitiesByIds(List<int?> ids)
        {
            using (var model = new DentalModel())
            {
                return ids.Select(id =>
                {
                    var info = model.ClinicalInformations.FirstOrDefault(i => i.ID == id);
                    return info?.Quantity;
                }).ToList();
            }
        }

        public List<decimal?> GetTotalAmountsByIds(List<int?> ids)
        {
            using (var model = new DentalModel())
            {
                return ids.Select(id =>
                {
                    var info = model.ClinicalInformations.FirstOrDefault(i => i.ID == id);
                    return info?.TotalAmount;
                }).ToList();
            }
        }

        public List<int?> GetClinicInfoIdsByInvoiceId(int invoiceId)
        {
            using (var model = new DentalModel())
            {
                return model.TreatmentInvoiceDetails
                    .Where(detail => detail.InvoiceID == invoiceId)
                    .Select(detail => detail.ClinicInfor_ID)
                    .ToList();
            }
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
        public int GetTreatmentQuantity(int treatmentID, DateTime startDate, DateTime endDate)
        {
            DentalModel model = new DentalModel();
            var totalQuantity = model.ClinicalInformations.AsEnumerable().Where(x => x.Treatment_ID == treatmentID && GetTreatmentInvoiceDate(x.ID) >= startDate && GetTreatmentInvoiceDate(x.ID) <= endDate)
                                                          .Sum(x => x.Quantity);
            return totalQuantity;
        }
    }
}
