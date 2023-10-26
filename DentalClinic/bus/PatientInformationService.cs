using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bus
{
    public class PatientInformationService
    {
        public List<PatientInformation> GetAll()
        {
            DentalModel context = new DentalModel();
            return context.PatientInformations.ToList();
        }

        public PatientInformation GetByID(string id)
        {
            DentalModel context = new DentalModel();
            return context.PatientInformations.FirstOrDefault(p => p.PatientID.ToString() == id);
        }

        public void InsertNew(PatientInformation newPatient)
        {
            using (var db = new DentalModel())
            {
                db.PatientInformations.Add(newPatient);
                db.SaveChanges();
            }
        }
        public void DeletePatient(string id)
        {
            using (var model = new DentalModel())
            {
                var selectedItem = model.PatientInformations.FirstOrDefault(t => t.PatientID.ToString() == id);
                if (selectedItem != null)
                {
                    model.PatientInformations.Remove(selectedItem);
                    model.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy bệnh nhân với ID: " + id);
                }
            }
        }

        public void UpdatePatientInformation(PatientInformation patientInfo)
        {
            using (var model = new DentalModel())
            {
                var existingPatient = model.PatientInformations.Find(patientInfo.PatientID);
                if (existingPatient != null)
                {
                    model.Entry(existingPatient).CurrentValues.SetValues(patientInfo);
                    model.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy thông tin bệnh nhân");
                }
            }
        }

        private bool IsPatientHavingTreatment(string id)
        {
            using (var model = new DentalModel())
            {
                return model.ClinicalInformations.Any(p => p.Patient_ID.ToString() == id);
            }
        }

        private bool IsPatientHavingMedic(string id)
        {
            using (var model = new DentalModel())
            {
                return model.PatientInformations.FirstOrDefault(p => p.PatientID.ToString() == id).Prescriptions.Any();
            }
        }

        public bool IsAbleToDelete(string id)
        {
            if(!IsPatientHavingMedic(id) && !IsPatientHavingTreatment(id))
            {
                return true;
            }
            return false;
        }

        public string JustGetName(string id)
        {
            using (var model = new DentalModel())
            {
                return model.PatientInformations.FirstOrDefault(p => p.PatientID.ToString() == id).FullName;
            }
        }
        public string JustGetAddress(string id)
        {
            using (var model = new DentalModel())
            {
                return model.PatientInformations.FirstOrDefault(p => p.PatientID.ToString() == id).Address;
            }
        }
    }
}
