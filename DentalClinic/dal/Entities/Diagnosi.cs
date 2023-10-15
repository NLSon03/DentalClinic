namespace dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Diagnosi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diagnosi()
        {
            ClinicalInformations = new HashSet<ClinicalInformation>();
        }

        public int ID { get; set; }

        public int? PatientID { get; set; }

        [StringLength(100)]
        public string Diagnosis { get; set; }

        public DateTime? ExaminationTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClinicalInformation> ClinicalInformations { get; set; }

        public virtual PatientInformation PatientInformation { get; set; }
    }
}
