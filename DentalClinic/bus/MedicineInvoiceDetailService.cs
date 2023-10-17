using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal.Entities;

namespace bus
{
    public class MedicineInvoiceDetailService
    {
        public List<MedicineInvoiceDetail> GetAll()
        {
            DentalModel model = new DentalModel();
            return model.MedicineInvoiceDetails.ToList();
        }

        public List<MedicineInvoiceDetail> GetAllByInvoiceID(int ID)
        {
            DentalModel model= new DentalModel();
            return model.MedicineInvoiceDetails.Where(p=>p.InvoiceID==ID).ToList();
        }
    }
}
