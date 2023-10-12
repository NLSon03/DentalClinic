namespace dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubClinicalInformation")]
    public partial class SubClinicalInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientID { get; set; }

        [StringLength(50)]
        public string BloodPressure { get; set; }

        [StringLength(50)]
        public string PulseRate { get; set; }

        [StringLength(50)]
        public string BloodSugarLevel { get; set; }

        public bool? BloodCoagulation { get; set; }

        public bool? CongenitalHeartDisease { get; set; }

        public bool? IntellectualDisability { get; set; }

        [StringLength(50)]
        public string XRayFilm { get; set; }

        [StringLength(50)]
        public string WarrantyID { get; set; }

        [StringLength(255)]
        public string Other { get; set; }

        public virtual PatientInformation PatientInformation { get; set; }
    }
}
