namespace dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Treatment")]
    public partial class Treatment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Treatment()
        {
            ClinicalInformation = new HashSet<ClinicalInformation>();
        }

        public int ID { get; set; }

        [Column("Treatment")]
        public int? Treatment1 { get; set; }

        public int? TreatmentMethod { get; set; }

        [Required]
        [StringLength(20)]
        public string Unit { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClinicalInformation> ClinicalInformation { get; set; }

        public virtual TreatmentName TreatmentName { get; set; }

        public virtual TreatmentMethodName TreatmentMethodName { get; set; }
    }
}
