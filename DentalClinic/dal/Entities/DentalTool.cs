namespace dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DentalTool
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DentalTool()
        {
            DentalToolTransactionsDetails = new HashSet<DentalToolTransactionsDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ToolID { get; set; }

        [Required]
        [StringLength(255)]
        public string ToolName { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        public int Quantity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DentalToolTransactionsDetail> DentalToolTransactionsDetails { get; set; }
    }
}
