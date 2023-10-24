using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bus
{
    public class TreatmentInvoiceService
    {
        public int InsertNewInvoiceAndReturnID()
        {
            var context = new DentalModel();
            var invoice = new TreatmentInvoice
            {
                Date = DateTime.Now,
                TotalAmount = null
            };
            context.TreatmentInvoices.Add(invoice);
            context.SaveChanges();

            return invoice.ID;
        }

        public void DeleteInvoiceByID(string id)
        {
            var context = new DentalModel();
            var invoiceId = int.Parse(id);

            // Find the invoice
            var invoice = context.TreatmentInvoices.FirstOrDefault(p => p.ID == invoiceId);

            if (invoice != null)
            {
                // Find all related details
                var details = context.TreatmentInvoiceDetails.Where(p => p.InvoiceID == invoiceId).ToList();

                // Remove details
                context.TreatmentInvoiceDetails.RemoveRange(details);

                // Remove the invoice
                context.TreatmentInvoices.Remove(invoice);

                // Save changes to the database
                context.SaveChanges();
            }
        }
        public List<TreatmentInvoice> GetAllByPatientID(string Id)
        {
            var context = new DentalModel();
            var treatmentInvoices = context.TreatmentInvoiceDetails
            .Include("TreatmentInvoices")
            .Include("ClinicalInformations")
            .Where(tid => tid.ClinicalInformation.Patient_ID.ToString() == Id)
            .Select(tid => tid.TreatmentInvoice)
            .Distinct()
            .ToList();

            return treatmentInvoices;
        }

        public string JustGetDate(int id)
        {
            using (var context = new DentalModel())
            {
                return context.TreatmentInvoices.FirstOrDefault(p => p.ID == id).Date.Value.ToString("dd/MM/yyyy");
            }
        }

        public string JustGetTotalAmount(int id)
        {
            using (var context = new DentalModel())
            {
                decimal totalAmount = context.TreatmentInvoices.FirstOrDefault(p => p.ID == id).TotalAmount.Value;
                return totalAmount.ToString("N0");
            }
        }
        public List<TreatmentInvoice> GetAll()
        {
            DentalModel model = new DentalModel();
            return model.TreatmentInvoices.ToList();
        }
    }
}
