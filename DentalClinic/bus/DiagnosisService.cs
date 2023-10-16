using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return model.Diagnosis.Where(p=>p.ID.ToString() == ID).ToList();
        }
    }
}
