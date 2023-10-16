namespace dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TreatmentInvoiceDetail")]
    public partial class TreatmentInvoiceDetail
    {
        public int ID { get; set; }

        public int? InvoiceID { get; set; }

        public int? ClinicInfor_ID { get; set; }

        public virtual ClinicalInformation ClinicalInformation { get; set; }

        public virtual TreatmentInvoice TreatmentInvoice { get; set; }
    }
}
