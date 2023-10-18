using dal.Entities;
using System.Collections.Generic;
using System.Linq;

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
    }
}
