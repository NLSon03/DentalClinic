using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bus
{
    public class DiagnosisService
    {
        public List<Diagnosi> GetAll()
        {
            DentalModel model = new DentalModel();
            return model.Diagnosis.ToList();
        }

        public List<Diagnosi> GetByID(string ID)
        {
            DentalModel model = new DentalModel();
            return model.Diagnosis.Where(p => p.ID.ToString() == ID).ToList();
        }

        public int AddDiagnosisAndReturnID(string diag)
        {
            var model = new DentalModel();
            var diagnosis = new Diagnosi
            {
                Diagnosis = diag,
                ExaminationTime = DateTime.Now
            };

            model.Diagnosis.Add(diagnosis);
            model.SaveChanges();
            return diagnosis.ID;
        }

        public void Update(Diagnosi diagnosi)
        {
            var context = new DentalModel();
            var diagnosis = context.Diagnosis.Find(diagnosi.ID);
            if(diagnosis!= null)
            {
                diagnosis.Diagnosis = diagnosi.Diagnosis;
                context.SaveChanges();
            }
        }
    }
}
