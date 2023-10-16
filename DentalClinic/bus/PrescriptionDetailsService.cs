using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal.Entities;
namespace bus
{
    public class PrescriptionDetailsService
    {
        public List<PrescriptionDetails> GetPrescriptionDetails()
        {
            DentalModel model = new DentalModel();
            return model.PrescriptionDetails.ToList();
        }
        public List<PrescriptionDetails> GetPrescriptionDetails(int Id)
        {
            DentalModel model = new DentalModel();
            return model.PrescriptionDetails.Where(x=>x.PrescriptionID == Id).ToList();
        }
    }
}
