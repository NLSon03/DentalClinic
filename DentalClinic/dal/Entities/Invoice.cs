namespace dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        public int InvoiceID { get; set; }

        public int ClinicalInfoID { get; set; }

        public DateTime? Date { get; set; }

        public decimal? TotalPayment { get; set; }

        public virtual ClinicalInformation ClinicalInformation { get; set; }
    }
}
