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
        public virtual DbSet<DentalMaterial> DentalMaterials { get; set; }
        public virtual DbSet<DentalTool> DentalTools { get; set; }
        public virtual DbSet<DentalToolTransaction> DentalToolTransactions { get; set; }
        public virtual DbSet<DentalToolTransactionsDetail> DentalToolTransactionsDetails { get; set; }
        public virtual DbSet<Diagnosi> Diagnosis { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<MedicineInvoice> MedicineInvoices { get; set; }
        public virtual DbSet<PatientInformation> PatientInformations { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<PrescriptionDetail> PrescriptionDetails { get; set; }
        public virtual DbSet<SubClinicalInformation> SubClinicalInformations { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<TreatmentMethodName> TreatmentMethodNames { get; set; }
        public virtual DbSet<TreatmentName> TreatmentNames { get; set; }
        public virtual DbSet<WarrantyInformation> WarrantyInformations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClinicalInformation>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DentalMaterial>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DentalMaterial>()
                .Property(e => e.TotalAmount)
                .HasPrecision(21, 2);

            modelBuilder.Entity<DentalToolTransaction>()
                .Property(e => e.TotalAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DentalToolTransactionsDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DentalToolTransactionsDetail>()
                .Property(e => e.TotalAmount)
                .HasPrecision(21, 2);

            modelBuilder.Entity<Diagnosi>()
                .HasMany(e => e.ClinicalInformations)
                .WithOptional(e => e.Diagnosi)
                .HasForeignKey(e => e.Diagnosis_ID);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.TotalPayment)
                .HasPrecision(10, 2);

            modelBuilder.Entity<InvoiceDetail>()
                .Property(e => e.TotalAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<MedicineInvoice>()
                .Property(e => e.TotalAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PatientInformation>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PatientInformation>()
                .HasMany(e => e.ClinicalInformations)
                .WithOptional(e => e.PatientInformation)
                .HasForeignKey(e => e.Patient_ID);

            modelBuilder.Entity<PatientInformation>()
                .HasOptional(e => e.SubClinicalInformation)
                .WithRequired(e => e.PatientInformation)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Prescription>()
                .Property(e => e.TotalAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Prescription>()
                .HasMany(e => e.MedicineInvoices)
                .WithRequired(e => e.Prescription)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PrescriptionDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PrescriptionDetail>()
                .Property(e => e.TotalAmount)
                .HasPrecision(21, 2);

            modelBuilder.Entity<SubClinicalInformation>()
                .Property(e => e.BloodCoagulation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SubClinicalInformation>()
                .Property(e => e.WarrantyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Treatment>()
                .HasMany(e => e.ClinicalInformations)
                .WithOptional(e => e.Treatment)
                .HasForeignKey(e => e.Treatment_ID);

            modelBuilder.Entity<TreatmentMethodName>()
                .HasMany(e => e.Treatments)
                .WithOptional(e => e.TreatmentMethodName)
                .HasForeignKey(e => e.TreatmentMethod);

            modelBuilder.Entity<TreatmentName>()
                .HasMany(e => e.Treatments)
                .WithOptional(e => e.TreatmentName)
                .HasForeignKey(e => e.Treatment1);

            modelBuilder.Entity<WarrantyInformation>()
                .Property(e => e.WarrantyID)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
