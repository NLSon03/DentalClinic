using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class ClinicalInformationService
    {
        public List<ClinicalInformation> GetAll()
        {
            DentalModel model = new DentalModel();
            return model.ClinicalInformations.ToList();
        }

        public List<ClinicalInformation> GetByID(string ID)
        {
            DentalModel model = new DentalModel();
            return model.ClinicalInformations.Where(p => p.Patient_ID.ToString() == ID).ToList();
        }
    }
}
