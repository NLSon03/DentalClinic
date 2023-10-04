namespace dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubclinicalInformation")]
    public partial class SubclinicalInformation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string BloodPressure { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string PulseRate { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string BloodSugarLevel { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string BloodCoagulation { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string CongenitalHeartDisease { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string IntellectualDisability { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string XRayFilm { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string WarrantyID { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(255)]
        public string Other { get; set; }

        public virtual PatientInformation PatientInformation { get; set; }

        public virtual WarrantyInformation WarrantyInformation { get; set; }
    }
}
