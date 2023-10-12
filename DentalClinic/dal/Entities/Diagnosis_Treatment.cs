namespace dal.Entities
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
            ClinicalInformationDetails = new HashSet<ClinicalInformationDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Diagnosis_Treatment_ID { get; set; }

        [StringLength(255)]
        public string DiagnosisName { get; set; }

        [StringLength(255)]
        public string TreatmentName { get; set; }

        [StringLength(50)]
        public string Unit { get; set; }

        public decimal? UnitPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClinicalInformationDetail> ClinicalInformationDetails { get; set; }
    }
}
