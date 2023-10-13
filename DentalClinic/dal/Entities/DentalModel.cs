using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace dal.Entities
{
    public partial class DentalModel : DbContext
    {
        public DentalModel()
            : base("name=DentalModel")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<ClinicalInformation> ClinicalInformations { get; set; }
        public virtual DbSet<ClinicalInformationDetail> ClinicalInformationDetails { get; set; }
        public virtual DbSet<DentalTool> DentalTools { get; set; }
        public virtual DbSet<DentalToolTransaction> DentalToolTransactions { get; set; }
        public virtual DbSet<DentalToolTransactionsDetail> DentalToolTransactionsDetails { get; set; }
        public virtual DbSet<Diagnosis_Treatment> Diagnosis_Treatment { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<PatientInformation> PatientInformations { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<PrescriptionDetail> PrescriptionDetails { get; set; }
        public virtual DbSet<SubClinicalInformation> SubClinicalInformations { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClinicalInformationDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ClinicalInformationDetail>()
                .Property(e => e.TotalAmount)
                .HasPrecision(21, 2);

            modelBuilder.Entity<ClinicalInformationDetail>()
                .HasMany(e => e.InvoiceDetails)
                .WithRequired(e => e.ClinicalInformationDetail)
                .HasForeignKey(e => e.ClinicalInfoDetailsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DentalToolTransaction>()
                .Property(e => e.TotalAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DentalToolTransactionsDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DentalToolTransactionsDetail>()
                .Property(e => e.TotalAmount)
                .HasPrecision(21, 2);

            modelBuilder.Entity<Diagnosis_Treatment>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.TotalPayment)
                .HasPrecision(10, 2);

            modelBuilder.Entity<InvoiceDetail>()
                .Property(e => e.TotalAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PatientInformation>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PatientInformation>()
                .HasOptional(e => e.SubClinicalInformation)
                .WithRequired(e => e.PatientInformation)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Prescription>()
                .Property(e => e.TotalAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PrescriptionDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PrescriptionDetail>()
                .Property(e => e.TotalAmount)
                .HasPrecision(21, 2);

            /*modelBuilder.Entity<SubClinicalInformation>()
                .Property(e => e.WarrantyID)
                .IsFixedLength()
                .IsUnicode(false);*/
        }
    }
}
