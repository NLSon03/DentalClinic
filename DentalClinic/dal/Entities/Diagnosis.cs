namespace dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Diagnosis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diagnosis()
        {
            ClinicalInformation = new HashSet<ClinicalInformation>();
        }

        public int ID { get; set; }

        public int? PatientID { get; set; }

        [Column("Diagnosis")]
        [StringLength(100)]
        public string Diagnosis1 { get; set; }

        public DateTime? ExaminationTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClinicalInformation> ClinicalInformation { get; set; }

        public virtual PatientInformation PatientInformation { get; set; }
    }
}
