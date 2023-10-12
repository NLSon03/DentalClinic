namespace dal.Entities
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
            ClinicalInformationDetails = new HashSet<ClinicalInformationDetail>();
            Invoices = new HashSet<Invoice>();
            Prescriptions = new HashSet<Prescription>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClinicalInfoID { get; set; }

        public int PatientID { get; set; }

        public DateTime? ExaminationDate { get; set; }

        [StringLength(255)]
        public string Diagnosis { get; set; }

        [StringLength(255)]
        public string Treatment { get; set; }

        public virtual PatientInformation PatientInformation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClinicalInformationDetail> ClinicalInformationDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
