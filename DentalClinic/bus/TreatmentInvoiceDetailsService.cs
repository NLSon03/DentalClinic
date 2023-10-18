using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class TreatmentInvoiceDetailsService
    {
        public TreatmentInvoiceDetail GetByClinicInforID(string ClinicID)
        {
            var context = new DentalModel();
            return context.TreatmentInvoiceDetails.FirstOrDefault(p=>p.ClinicInfor_ID.ToString()==ClinicID);
        }
    }
}
