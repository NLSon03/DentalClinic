namespace dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MedicineInvoiceDetail")]
    public partial class MedicineInvoiceDetail
    {
        public int ID { get; set; }

        public int? InvoiceID { get; set; }

        public int? Prescription_ID { get; set; }

        public virtual MedicineInvoice MedicineInvoice { get; set; }

        public virtual Prescription Prescription { get; set; }
    }
}
