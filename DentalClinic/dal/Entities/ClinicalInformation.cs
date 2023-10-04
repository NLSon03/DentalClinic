namespace dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClinicalInformation")]
    public partial class ClinicalInformation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClinicalInformation()
        {
            Invoices = new HashSet<Invoice>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClinicalInformationId { get; set; }

        public int PatientID { get; set; }

        public int DiagnosisTreatmentID { get; set; }

        public int? Quantity { get; set; }

        public decimal? TotalAmount { get; set; }

        public virtual Diagnosis_Treatment Diagnosis_Treatment { get; set; }

        public virtual PatientInformation PatientInformation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
