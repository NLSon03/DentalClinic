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
        public virtual DbSet<DentalTool> DentalTools { get; set; }
        public virtual DbSet<DentalToolTransaction> DentalToolTransactions { get; set; }
        public virtual DbSet<DentalToolTransactionsDetail> DentalToolTransactionsDetails { get; set; }
        public virtual DbSet<Diagnosi> Diagnosis { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<MedicineInvoice> MedicineInvoices { get; set; }
        public virtual DbSet<MedicineInvoiceDetail> MedicineInvoiceDetails { get; set; }
        public virtual DbSet<PatientInformation> PatientInformations { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<SubClinicalInformation> SubClinicalInformations { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<TreatmentInvoice> TreatmentInvoices { get; set; }
        public virtual DbSet<TreatmentInvoiceDetail> TreatmentInvoiceDetails { get; set; }
        public virtual DbSet<TreatmentMethodName> TreatmentMethodNames { get; set; }
        public virtual DbSet<TreatmentName> TreatmentNames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClinicalInformation>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ClinicalInformation>()
                .HasMany(e => e.TreatmentInvoiceDetails)
                .WithOptional(e => e.ClinicalInformation)
                .HasForeignKey(e => e.ClinicInfor_ID)
                .WillCascadeOnDelete();

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

            modelBuilder.Entity<Medicine>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Medicine>()
                .HasMany(e => e.Prescriptions)
                .WithOptional(e => e.Medicine)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MedicineInvoice>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MedicineInvoice>()
                .HasMany(e => e.MedicineInvoiceDetails)
                .WithOptional(e => e.MedicineInvoice)
                .HasForeignKey(e => e.InvoiceID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PatientInformation>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PatientInformation>()
                .HasMany(e => e.ClinicalInformations)
                .WithOptional(e => e.PatientInformation)
                .HasForeignKey(e => e.Patient_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PatientInformation>()
                .HasOptional(e => e.SubClinicalInformation)
                .WithRequired(e => e.PatientInformation)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PatientInformation>()
                .HasMany(e => e.Prescriptions)
                .WithOptional(e => e.PatientInformation)
                .HasForeignKey(e => e.Patient_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Prescription>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Prescription>()
                .HasMany(e => e.MedicineInvoiceDetails)
                .WithOptional(e => e.Prescription)
                .HasForeignKey(e => e.Prescription_ID)
                .WillCascadeOnDelete();

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

            modelBuilder.Entity<TreatmentInvoice>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TreatmentInvoice>()
                .HasMany(e => e.TreatmentInvoiceDetails)
                .WithOptional(e => e.TreatmentInvoice)
                .HasForeignKey(e => e.InvoiceID);

            modelBuilder.Entity<TreatmentMethodName>()
                .HasMany(e => e.Treatments)
                .WithOptional(e => e.TreatmentMethodName)
                .HasForeignKey(e => e.TreatmentMethod)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TreatmentName>()
                .HasMany(e => e.Treatments)
                .WithOptional(e => e.TreatmentName)
                .HasForeignKey(e => e.Treatment1)
                .WillCascadeOnDelete();
        }
    }
}
