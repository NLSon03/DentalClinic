namespace DentalClinic.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DentalMaterial
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Content { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? TotalAmount { get; set; }
    }
}
