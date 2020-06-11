using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication1.DTOs.Requests;
using WebApplication1.Models;

namespace WebApplication1.Services
{
	public class SqlServerDbService : IDbService
	{
		private readonly CodeFirstDbContext _context;
		public SqlServerDbService(CodeFirstDbContext context)
		{
			_context = context;
		}
		public void AddDoctor(AddOrUpdateDoctorRequest req)
		{
			var addedDoctor = _context.Add(new Doctor { FirstName = req.FirstName, LastName = req.LastName, Email = req.Email });
			_context.SaveChanges();
		}

		public void DeleteDoctor(int id)
		{
			var doctor = _context.Doctor.Find(id);
			if (doctor == null)
			{
				return;
			}
			var prescriptions = _context.Prescription.Where(e => e.IdDoctor == id);
			foreach (var prescription in prescriptions)
			{
				doctor.Prescription.Remove(prescription);
			}
			_context.Remove(doctor);
			_context.SaveChanges();
		}

		public IEnumerable<Doctor> GetDoctors()
		{
			return _context.Doctor.ToList();
		}

		public void UpdateDoctor(AddOrUpdateDoctorRequest req, int id)
		{
			var doctor = _context.Doctor.Find(id);
			if (doctor == null)
			{
				return;
			}

			_context.Entry(doctor).CurrentValues.SetValues(req);
			_context.SaveChanges();
		}

	}
}
