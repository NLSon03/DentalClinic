using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class TreatmentMethodNameService
    {
        public List<TreatmentMethodName> GetAll()
        {
            DentalModel model = new DentalModel();
            return model.TreatmentMethodNames.ToList();
        }

        public List<TreatmentMethodName> GetByListTreatment(List<Treatment> list)
        {
            var model = new DentalModel();
            return model.TreatmentMethodNames.Where(item1 => list.Any(item2 => item2.Treatment1 == item1.ID)).ToList();
        }
    }
}
