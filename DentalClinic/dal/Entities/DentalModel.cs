using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace dal.Entities
{
    public partial class DentalModel : DbContext
    {
        public DentalModel()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<ClinicalInformation> ClinicalInformation { get; set; }
        public virtual DbSet<DentalTools> DentalTools { get; set; }
        public virtual DbSet<DentalToolTransactions> DentalToolTransactions { get; set; }
        public virtual DbSet<DentalToolTransactionsDetails> DentalToolTransactionsDetails { get; set; }
        public virtual DbSet<Diagnosis> Diagnosis { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<MedicineInvoice> MedicineInvoice { get; set; }
        public virtual DbSet<PatientInformation> PatientInformation { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<PrescriptionDetails> PrescriptionDetails { get; set; }
        public virtual DbSet<SubClinicalInformation> SubClinicalInformation { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Treatment> Treatment { get; set; }
        public virtual DbSet<TreatmentMethodName> TreatmentMethodName { get; set; }
        public virtual DbSet<TreatmentName> TreatmentName { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClinicalInformation>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ClinicalInformation>()
                .HasMany(e => e.Invoice)
                .WithRequired(e => e.ClinicalInformation)
                .HasForeignKey(e => e.ClinicalInfoID);

            modelBuilder.Entity<ClinicalInformation>()
                .HasMany(e => e.Prescription)
                .WithRequired(e => e.ClinicalInformation)
                .HasForeignKey(e => e.ClinicalInfoID);

            modelBuilder.Entity<DentalToolTransactions>()
                .Property(e => e.TotalAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DentalToolTransactionsDetails>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DentalToolTransactionsDetails>()
                .Property(e => e.TotalAmount)
                .HasPrecision(21, 2);

            modelBuilder.Entity<Diagnosis>()
                .HasMany(e => e.ClinicalInformation)
                .WithOptional(e => e.Diagnosis)
                .HasForeignKey(e => e.Diagnosis_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Invoice>()
                .Property(e => e.TotalPayment)
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
                .HasMany(e => e.Diagnosis)
                .WithOptional(e => e.PatientInformation)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PatientInformation>()
                .HasOptional(e => e.SubClinicalInformation)
                .WithRequired(e => e.PatientInformation)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PrescriptionDetails>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PrescriptionDetails>()
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
                .HasMany(e => e.ClinicalInformation)
                .WithOptional(e => e.Treatment)
                .HasForeignKey(e => e.Treatment_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TreatmentMethodName>()
                .HasMany(e => e.Treatment)
                .WithOptional(e => e.TreatmentMethodName)
                .HasForeignKey(e => e.TreatmentMethod)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TreatmentName>()
                .HasMany(e => e.Treatment)
                .WithOptional(e => e.TreatmentName)
                .HasForeignKey(e => e.Treatment1)
                .WillCascadeOnDelete();
        }
    }
}
