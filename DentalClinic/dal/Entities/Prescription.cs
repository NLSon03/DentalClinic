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
            MedicineInvoiceDetails = new HashSet<MedicineInvoiceDetail>();
        }

        public int ID { get; set; }

        public int? Patient_ID { get; set; }

        public int? MedicineID { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalAmount { get; set; }

        public virtual Medicine Medicine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicineInvoiceDetail> MedicineInvoiceDetails { get; set; }

        public virtual PatientInformation PatientInformation { get; set; }
    }
}
