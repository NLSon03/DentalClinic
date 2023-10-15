namespace dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WarrantyInformation")]
    public partial class WarrantyInformation
    {
        [Key]
        [StringLength(50)]
        public string WarrantyID { get; set; }

        [Required]
        [StringLength(100)]
        public string LaboName { get; set; }
    }
}
