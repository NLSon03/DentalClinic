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
    }
}
