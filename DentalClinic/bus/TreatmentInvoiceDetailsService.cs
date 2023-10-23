using dal.Entities;
using System.Collections.Generic;
using System.Linq;

namespace bus
{
    public class TreatmentInvoiceDetailsService
    {
        public TreatmentInvoiceDetail GetByClinicInforID(string ClinicID)
        {
            var context = new DentalModel();
            return context.TreatmentInvoiceDetails.FirstOrDefault(p => p.ClinicInfor_ID.ToString() == ClinicID);
        }

        public void InsertInforForInvoice(int idInvoice, List<int> ClinicID)
        {
            var context = new DentalModel();
            foreach (var item in ClinicID)
            {
                var treatmentInvoiceDetails = new TreatmentInvoiceDetail
                {
                    InvoiceID = idInvoice,
                    ClinicInfor_ID = item
                };
                context.TreatmentInvoiceDetails.Add(treatmentInvoiceDetails);

            }
            context.SaveChanges();
        }

        public List<int?> GetClinicInfoIdsByInvoiceId(int invoiceId)
        {
            using (var context = new DentalModel())
            {
                return context.TreatmentInvoiceDetails
                    .Where(detail => detail.InvoiceID == invoiceId)
                    .Select(detail => detail.ClinicInfor_ID)
                    .ToList();
            }
        }
    }
}
