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
            return model.ClinicalInformation.ToList();
        }

        public List<ClinicalInformation> GetByID(string ID)
        {
            DentalModel model = new DentalModel();
            return model.ClinicalInformation.Where(p => p.ID.ToString() == ID).ToList();
        }
    }
}
