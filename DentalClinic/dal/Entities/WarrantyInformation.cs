namespace dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WarrantyInformation")]
    public partial class WarrantyInformation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WarrantyInformation()
        {
            SubclinicalInformations = new HashSet<SubclinicalInformation>();
        }

        [Key]
        [StringLength(50)]
        public string WarrantyID { get; set; }

        [Required]
        [StringLength(100)]
        public string LaboName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubclinicalInformation> SubclinicalInformations { get; set; }
    }
}
