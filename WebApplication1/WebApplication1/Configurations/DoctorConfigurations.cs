using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
	public class DoctorConfigurations : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> modelBuilder)
        {
            modelBuilder.HasKey(e => e.IdDoctor);

            modelBuilder.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

            modelBuilder.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

            modelBuilder.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsRequired();

            var doctors = new List<Doctor>();

            doctors.Add(new Doctor { IdDoctor = 1, FirstName = "Adam", LastName = "Adamowicz", Email = "aa@a.pl" });
                doctors.Add(new Doctor { IdDoctor = 2, FirstName = "Bartłomiej", LastName = "Bart", Email = "bb@b.pl" });
                doctors.Add(new Doctor { IdDoctor = 3, FirstName = "Cezary", LastName = "Cesarz", Email = "cc@c.pl" });
                doctors.Add(new Doctor { IdDoctor = 4, FirstName = "Dariusz", LastName = "Dziekanowski", Email = "dd@d.pl" });

            modelBuilder.HasData(doctors);
         }
	}
}
