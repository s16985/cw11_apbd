using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
	public class PrescriptionConfigurations : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> modelBuilder)
        {
            modelBuilder.HasKey(e => e.IdPrescription);

            modelBuilder.Property(e => e.Date).HasColumnType("date");

            modelBuilder.Property(e => e.DueDate).HasColumnType("date");

            modelBuilder.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Doctor");

            modelBuilder.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Patient");

            var prescriptions = new List<Prescription>();

            prescriptions.Add(new Prescription { IdPrescription = 41, IdDoctor = 1, IdPatient = 11, Date = new DateTime(), DueDate = new DateTime() });
            prescriptions.Add(new Prescription { IdPrescription = 42, IdDoctor = 2, IdPatient = 21, Date = new DateTime(), DueDate = new DateTime() });
            prescriptions.Add(new Prescription { IdPrescription = 43, IdDoctor = 3, IdPatient = 31, Date = new DateTime(), DueDate = new DateTime() });
            prescriptions.Add(new Prescription { IdPrescription = 44, IdDoctor = 4, IdPatient = 41, Date = new DateTime(), DueDate = new DateTime() });

            modelBuilder.HasData(prescriptions);
        }
	}
}
