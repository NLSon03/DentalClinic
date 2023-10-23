using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class PatientInformationService
    {
        public List<PatientInformation> GetAll()
        {
            DentalModel context = new DentalModel();
            return context.PatientInformations.ToList();
        }

        public PatientInformation GetByID(string id)
        {
            DentalModel context = new DentalModel();
            return context.PatientInformations.FirstOrDefault(p=>p.PatientID.ToString() == id);
        }


        public string JustGetName(string id)
        {
            using(var model = new DentalModel())
            {
                return model.PatientInformations.FirstOrDefault(p=>p.PatientID.ToString() == id).FullName;
            }
        }
        public string JustGetAddress(string id)
        {
            using (var model = new DentalModel())
            {
                return model.PatientInformations.FirstOrDefault(p => p.PatientID.ToString() == id).Address;
            }
        }
    }
}
