namespace dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MedicineInvoice")]
    public partial class MedicineInvoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceID { get; set; }

        public int PrescriptionID { get; set; }

        public decimal? TotalAmount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InvoiceDate { get; set; }

        public virtual Prescription Prescription { get; set; }
    }
}
