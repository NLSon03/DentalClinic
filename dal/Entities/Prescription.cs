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
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PrescriptionID { get; set; }

        public int PatientID { get; set; }

        public int MedicineID { get; set; }

        public int Quantity { get; set; }

        public decimal TotalAmount { get; set; }

        public virtual Medicine Medicine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicineInvoice> MedicineInvoices { get; set; }

        public virtual PatientInformation PatientInformation { get; set; }
    }
}
