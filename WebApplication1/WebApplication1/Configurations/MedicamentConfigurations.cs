using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class MedicamentConfigurations : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> modelBuilder)
        {
            modelBuilder.HasKey(e => e.IdMedicament);

            modelBuilder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Property(e => e.Description)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Property(e => e.Type)
                .HasMaxLength(100)
                .IsRequired();


            var medicaments = new List<Medicament>();

            medicaments.Add(new Medicament { IdMedicament = 11, Name = "Apap", Description = "Przeciwbólowy", Type = "Tabletki" });
            medicaments.Add(new Medicament { IdMedicament = 12, Name = "Ibuprom", Description = "Przeciwbólowy", Type = "Tabletki" });
            medicaments.Add(new Medicament { IdMedicament = 13, Name = "Eurespal", Description = "Przecizapalny", Type = "Syrop" });
            medicaments.Add(new Medicament { IdMedicament = 14, Name = "Rutinoscorbin", Description = "Witamina C", Type = "Tabletki" });

            modelBuilder.HasData(medicaments);
        }
	}
}
