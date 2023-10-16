using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal.Entities;
namespace bus
{
    public class PrescriptionService
    {
        public List<Prescription> GetAll()
        {
            DentalModel dentalModel = new DentalModel();
            return dentalModel.Prescription.ToList();
        }
    }
}
