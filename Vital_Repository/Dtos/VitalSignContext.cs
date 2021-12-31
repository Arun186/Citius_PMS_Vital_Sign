using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Vital_Repository.Dtos
{
    public partial class VitalSignContext : DbContext
    {
        public VitalSignContext()
        {
        }

        public VitalSignContext(DbContextOptions<VitalSignContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Diagnosis> Diagnosis { get; set; }
        public virtual DbSet<Medication> Medication { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientVisit> PatientVisit { get; set; }
        public virtual DbSet<Pprocedure> Pprocedure { get; set; }
        public virtual DbSet<VitalSigns> VitalSigns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TanveerU\Downloads\PMS.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnosis>(entity =>
            {
                entity.HasIndex(e => e.Dcode)
                    .HasName("constraint_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dcode)
                    .IsRequired()
                    .HasColumnName("dcode")
                    .HasMaxLength(10);

                entity.Property(e => e.Ddepricated).HasColumnName("ddepricated");

                entity.Property(e => e.Ddescription).HasColumnName("ddescription");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.Property(e => e.ActiveIngredient)
                    .HasColumnName("active_ingredient")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ApplNo)
                    .HasColumnName("appl_no")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DrugName)
                    .HasColumnName("drug_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DrugStrength)
                    .HasColumnName("drug_strength")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductForm)
                    .HasColumnName("product_form")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductNo)
                    .HasColumnName("product_no")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceDrug)
                    .HasColumnName("reference_drug")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceStandard)
                    .HasColumnName("reference_standard")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Contactno)
                    .HasColumnName("contactno")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Dateofbirth)
                    .HasColumnName("dateofbirth")
                    .HasColumnType("datetime");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddress)
                    .HasColumnName("homeAddress")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Languages)
                    .HasColumnName("languages")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Race)
                    .HasColumnName("race")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<PatientVisit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dcode)
                    .HasColumnName("dcode")
                    .HasMaxLength(10);

                entity.Property(e => e.Medid).HasColumnName("medid");

                entity.Property(e => e.Pcode)
                    .HasColumnName("pcode")
                    .HasMaxLength(10);

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.HasOne(d => d.Med)
                    .WithMany(p => p.PatientVisit)
                    .HasForeignKey(d => d.Medid)
                    .HasConstraintName("FK_PatientVisit_Diagnosis");
            });

            modelBuilder.Entity<Pprocedure>(entity =>
            {
                entity.ToTable("PProcedure");

                entity.HasIndex(e => e.Pcode)
                    .HasName("constraint_name1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Pcode)
                    .HasColumnName("pcode")
                    .HasMaxLength(10);

                entity.Property(e => e.Pdepricated).HasColumnName("pdepricated");

                entity.Property(e => e.Pdescription).HasColumnName("pdescription");
            });

            modelBuilder.Entity<VitalSigns>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BloodPressure)
                    .HasColumnName("bloodPressure")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BodyTemperature)
                    .HasColumnName("bodyTemperature")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasMaxLength(5);

                entity.Property(e => e.Patientid).HasColumnName("patientid");

                entity.Property(e => e.RespirationRate)
                    .HasColumnName("respirationRate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasMaxLength(5);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.VitalSigns)
                    .HasForeignKey(d => d.Patientid)
                    .HasConstraintName("Fk_Patient");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
