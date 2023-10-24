using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class TreatmentService
    {
        public List<Treatment> GetAll()
        {
            DentalModel model = new DentalModel();
            return model.Treatments.ToList();
        }
        public List<Treatment> GetByTreatmentNameID(string treatmentID)
        {
            var model = new DentalModel();
            return model.Treatments.Where(p => p.Treatment1.ToString() == treatmentID).ToList();
        }

        public Treatment GetByTreatmentNameID_And_TreatmentMethodID(string treatmentID, string treatmentMethodID)
        {
            var model = new DentalModel();
            return model.Treatments.FirstOrDefault(p=>p.Treatment1.ToString() == treatmentID&&p.TreatmentMethod.ToString()==treatmentMethodID);
        }

        public int GetID(string treatmentID, string treatmentMethodID) {
            var model = new DentalModel();
            return model.Treatments.FirstOrDefault(p => p.Treatment1.ToString() == treatmentID && p.TreatmentMethod.ToString() == treatmentMethodID).ID;
        }

    }
}
