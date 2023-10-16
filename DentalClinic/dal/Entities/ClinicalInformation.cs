namespace dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClinicalInformation")]
    public partial class ClinicalInformation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClinicalInformation()
        {
            TreatmentInvoiceDetails = new HashSet<TreatmentInvoiceDetail>();
        }

        public int ID { get; set; }

        public int? Patient_ID { get; set; }

        public int? Diagnosis_ID { get; set; }

        public int? Treatment_ID { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalAmount { get; set; }

        public virtual Diagnosi Diagnosi { get; set; }

        public virtual PatientInformation PatientInformation { get; set; }

        public virtual Treatment Treatment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TreatmentInvoiceDetail> TreatmentInvoiceDetails { get; set; }
    }
}
