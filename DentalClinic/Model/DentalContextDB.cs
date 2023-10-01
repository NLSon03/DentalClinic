using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DentalClinic.Model
{
    public partial class DentalContextDB : DbContext
    {
        public DentalContextDB()
            : base("name=DentalContextDB")
        {
        }

        public virtual DbSet<ClinicalInformation> ClinicalInformations { get; set; }
        public virtual DbSet<DentalMaterial> DentalMaterials { get; set; }
        public virtual DbSet<Diagnosis_Treatment> Diagnosis_Treatment { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<PatientInformation> PatientInformations { get; set; }
        public virtual DbSet<WarrantyInformation> WarrantyInformations { get; set; }
        public virtual DbSet<SubclinicalInformation> SubclinicalInformations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClinicalInformation>()
                .Property(e => e.TotalAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ClinicalInformation>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.ClinicalInformation)
                .HasForeignKey(e => e.ClinicalInfoID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DentalMaterial>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DentalMaterial>()
                .Property(e => e.TotalAmount)
                .HasPrecision(21, 2);

            modelBuilder.Entity<Diagnosis_Treatment>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Diagnosis_Treatment>()
                .HasMany(e => e.ClinicalInformations)
                .WithRequired(e => e.Diagnosis_Treatment)
                .HasForeignKey(e => e.DiagnosisTreatmentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.TotalPayment)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PatientInformation>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PatientInformation>()
                .HasMany(e => e.ClinicalInformations)
                .WithRequired(e => e.PatientInformation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PatientInformation>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.PatientInformation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PatientInformation>()
                .HasMany(e => e.SubclinicalInformations)
                .WithRequired(e => e.PatientInformation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WarrantyInformation>()
                .Property(e => e.WarrantyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<WarrantyInformation>()
                .HasMany(e => e.SubclinicalInformations)
                .WithRequired(e => e.WarrantyInformation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubclinicalInformation>()
                .Property(e => e.WarrantyID)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
