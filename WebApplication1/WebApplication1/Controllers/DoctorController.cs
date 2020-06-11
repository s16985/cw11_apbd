using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Requests;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDbService _service;
        public DoctorController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_service.GetDoctors());
        }

        [HttpPost("add")]
        public IActionResult AddDoctor(AddOrUpdateDoctorRequest req)
        {
            _service.AddDoctor(req);
            return Ok();
        }

        [HttpPatch("update/{id}")]
        public IActionResult UpdateDoctor(AddOrUpdateDoctorRequest req, int id)
        {
            _service.UpdateDoctor(req, id);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            _service.DeleteDoctor(id);
            return Ok();
        }
    }
}