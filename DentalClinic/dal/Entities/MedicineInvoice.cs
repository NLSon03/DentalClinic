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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedicineInvoice()
        {
            MedicineInvoiceDetails = new HashSet<MedicineInvoiceDetail>();
        }

        public int ID { get; set; }

        public DateTime? Date { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalAmount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicineInvoiceDetail> MedicineInvoiceDetails { get; set; }
    }
}
