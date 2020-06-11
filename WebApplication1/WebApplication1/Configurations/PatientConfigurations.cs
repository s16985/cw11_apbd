using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class PatientConfigurations : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> modelBuilder)
        {

            modelBuilder.HasKey(e => e.IdPatient);

            modelBuilder.Property(e => e.Birthdate).HasColumnType("date");

            modelBuilder.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

            modelBuilder.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

            var patients = new List<Patient>();

            patients.Add(new Patient { IdPatient = 11, FirstName = "Edgar", LastName = "Edgarovic", Birthdate = new DateTime(1989, 2, 2) });
            patients.Add(new Patient { IdPatient = 21, FirstName = "Filip", LastName = "Filipczak", Birthdate = new DateTime(1978, 2, 1) });
            patients.Add(new Patient { IdPatient = 31, FirstName = "Grzegorz", LastName = "Grzegorzewski", Birthdate = new DateTime(1967, 2, 1) });
            patients.Add(new Patient { IdPatient = 41, FirstName = "Henryk", LastName = "Sienkiewicz", Birthdate = new DateTime(1996, 1, 1) });

            modelBuilder.HasData(patients);
        }
            
	}
}
