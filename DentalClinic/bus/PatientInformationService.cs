using dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return context.PatientInformations.FirstOrDefault(p=>p.PatientID.ToString() == id);
        }

        public void InsertNew(PatientInformation newPatient) 
        {
            using(var  db = new DentalModel())
            {
                
                db.PatientInformations.Add(newPatient);
                db.SaveChanges();
            }
        }
        public void DeletePatient(string id)
        {
            using(var model = new DentalModel())
            {
                var selectedItem = model.PatientInformations.Where(t => t.PatientID.ToString()== id).FirstOrDefault();
                model.PatientInformations.Remove(selectedItem);
                model.SaveChanges();
            }
        }
        public void EditInfo(PatientInformation info)
        {
            using (var db = new DentalModel())
            {
                db.PatientInformations.AddOrUpdate(info);
                db.SaveChanges();
            }
        }
    }
}
