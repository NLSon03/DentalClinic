namespace dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PatientInformation")]
    public partial class PatientInformation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PatientInformation()
        {
            ClinicalInformations = new HashSet<ClinicalInformation>();
            Prescriptions = new HashSet<Prescription>();
        }

        [Key]
        public int PatientID { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public bool Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime YearOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        public DateTime? FirstExaminationDate { get; set; }

        [Required]
        [StringLength(255)]
        public string ReasonForExamination { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClinicalInformation> ClinicalInformations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescription> Prescriptions { get; set; }

        public virtual SubClinicalInformation SubClinicalInformation { get; set; }
    }
}
