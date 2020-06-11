using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
	public class PrescriptionMedicamentConfigurations : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> modelBuilder)
        {
            modelBuilder.HasKey(e => new { e.IdMedicament, e.IdPrescription });

            modelBuilder.ToTable("Prescription_Medicament");

            modelBuilder.Property(e => e.Details)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.HasOne(d => d.IdMedicamentNavigation)
                .WithMany(p => p.PrescriptionMedicament)
                .HasForeignKey(d => d.IdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_Medicament_Medicament");

            modelBuilder.HasOne(d => d.IdPrescriptionNavigation)
                .WithMany(p => p.PrescriptionMedicament)
                .HasForeignKey(d => d.IdPrescription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_Medicament_Prescription");

            var prescriptionsMedicaments = new List<PrescriptionMedicament>();

            prescriptionsMedicaments.Add(new PrescriptionMedicament { IdMedicament = 11, IdPrescription = 41, Details = "Szczegóły recepty: ", Dose = 10 });
            prescriptionsMedicaments.Add(new PrescriptionMedicament { IdMedicament = 12, IdPrescription = 42, Details = "Szczegóły recepty: ", Dose = 20 });
            prescriptionsMedicaments.Add(new PrescriptionMedicament { IdMedicament = 13, IdPrescription = 43, Details = "Szczegóły recepty: ", Dose = 30 });
            prescriptionsMedicaments.Add(new PrescriptionMedicament { IdMedicament = 14, IdPrescription = 44, Details = "Szczegóły recepty: ", Dose = 40 });

            modelBuilder.HasData(prescriptionsMedicaments);
        }
    }
}
