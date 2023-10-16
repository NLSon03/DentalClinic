using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal.Entities;
namespace bus
{
    public class SubClinicalInformationService
    {
        public SubClinicalInformation GetById(string id)
        {
            DentalModel context = new DentalModel();
            return context.SubClinicalInformation.FirstOrDefault(p => p.PatientID.ToString() == id);
        }
    }
}
