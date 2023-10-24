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

        public void InsertInforForInvoice(int idInvoice, List<int> ClinicID)
        {
            var context = new DentalModel();
            foreach (var item in ClinicID)
            {
                var detailsMedInvoice = new MedicineInvoiceDetail()
                {
                    Prescription_ID = item,
                    InvoiceID = idInvoice
                };
                context.MedicineInvoiceDetails.Add(detailsMedInvoice);

            }
            context.SaveChanges();
        }
    }
}
