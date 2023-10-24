using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class MedicineInvoiceService
    { 
        public List<MedicineInvoice> GetAll()
        {
            DentalModel model = new DentalModel();
            return model.MedicineInvoices.ToList();
        }
        public string JustGetDate(int id)
        {
            using (var context = new DentalModel())
            {
                return context.MedicineInvoices.FirstOrDefault(p => p.ID == id).Date.Value.ToString("dd/MM/yyyy");
            }
        }
        public int InsertNewInvoiceAndReturnID()
        {
            var context = new DentalModel();
            var invoice = new MedicineInvoice()
            {
                Date = DateTime.Now,
                TotalAmount = 0
            };
            context.MedicineInvoices.Add(invoice);
            context.SaveChanges();

            return invoice.ID;
        }
        public void InsertNew(MedicineInvoice medInvoice)
        {
            using (DentalModel model = new DentalModel()) 
            {
                model.MedicineInvoices.Add(medInvoice);
                model.SaveChanges();
            }
        }
    }
}
