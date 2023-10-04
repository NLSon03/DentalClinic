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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceID { get; set; }

        public int PatientID { get; set; }

        public int ClinicalInfoID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public decimal? TotalPayment { get; set; }

        public virtual ClinicalInformation ClinicalInformation { get; set; }

        public virtual PatientInformation PatientInformation { get; set; }
    }
}
