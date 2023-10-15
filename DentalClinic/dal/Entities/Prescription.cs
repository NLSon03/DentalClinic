namespace dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prescription")]
    public partial class Prescription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prescription()
        {
            MedicineInvoices = new HashSet<MedicineInvoice>();
            PrescriptionDetails = new HashSet<PrescriptionDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PrescriptionID { get; set; }

        public int ClinicalInfoID { get; set; }

        public decimal? TotalAmount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicineInvoice> MedicineInvoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }
    }
}
