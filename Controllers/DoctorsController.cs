using System.Threading.Tasks;
using cw_8_ko_xDejw.Models.Medicine.DTOs;
using cw_8_ko_xDejw.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cw_8_ko_xDejw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMedService _service;
        public DoctorsController(IMedService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> AddDoctor(Doctor data)
        {
            await _service.AddDoctor(data);
            await _service.SaveDatabase();
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> UpdateDoctor(int id, Doctor data)
        {
            var doctor = await _service.GetDoctorByID(id);
            if(doctor == null) return NotFound();
            
            doctor.FirstName = data.FirstName;
            doctor.LastName = data.LastName;
            doctor.Email = data.Email;
            
            await _service.SaveDatabase();
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _service.GetDoctorByID(id);
            if(doctor == null) return NotFound();

            _service.DeleteDoctor(doctor);

            await _service.SaveDatabase();
            return Ok();
        }
        
    }
}