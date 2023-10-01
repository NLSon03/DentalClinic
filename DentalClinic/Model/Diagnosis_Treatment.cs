namespace DentalClinic.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Diagnosis_Treatment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diagnosis_Treatment()
        {
            ClinicalInformations = new HashSet<ClinicalInformation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string DiagnosisName { get; set; }

        [Required]
        [StringLength(100)]
        public string TreatmentName { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        public decimal UnitPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClinicalInformation> ClinicalInformations { get; set; }
    }
}
