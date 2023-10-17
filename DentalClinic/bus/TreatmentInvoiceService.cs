using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class TreatmentInvoiceService
    {
        public List<TreatmentInvoice> GetAll()
        {
            DentalModel model = new DentalModel();
            return model.TreatmentInvoices.ToList();
        }
    }
}
