using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal.Entities;
namespace bus
{
    public class PatientInformationService
    {
        public List<PatientInformation> GetAll()
        {
            DentalModel context = new DentalModel();
            return context.PatientInformation.ToList();
        }

        public PatientInformation GetByID(string id)
        {
            DentalModel context = new DentalModel();
            return context.PatientInformation.FirstOrDefault(p=>p.PatientID.ToString() == id);
        }

    }
}
