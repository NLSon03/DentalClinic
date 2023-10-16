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
    }
}
