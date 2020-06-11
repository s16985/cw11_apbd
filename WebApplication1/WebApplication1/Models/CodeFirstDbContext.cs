using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Configurations;

namespace WebApplication1.Models
{
	public class CodeFirstDbContext : DbContext
	{
		public CodeFirstDbContext() { }

		public CodeFirstDbContext(DbContextOptions options)
			:base(options)
		{ }

		public virtual DbSet<Doctor> Doctor { get; set; }
		public virtual DbSet<Medicament> Medicament { get; set; }
		public virtual DbSet<Patient> Patient { get; set; }
		public virtual DbSet<Prescription> Prescription { get; set; }
		public virtual DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoctorConfigurations());

            modelBuilder.ApplyConfiguration(new PrescriptionConfigurations());

            modelBuilder.ApplyConfiguration(new PatientConfigurations());

            modelBuilder.ApplyConfiguration(new MedicamentConfigurations());

            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentConfigurations());
        }
    }
}
