using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs.Requests;
using WebApplication1.Models;

namespace WebApplication1.Services
{
	public interface IDbService
	{
		public IEnumerable<Doctor> GetDoctors();
		public void AddDoctor(AddOrUpdateDoctorRequest req);
		public void UpdateDoctor(AddOrUpdateDoctorRequest req, int id);
		public void DeleteDoctor(int id);
	}
}
