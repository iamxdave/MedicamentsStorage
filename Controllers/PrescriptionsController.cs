using System.Linq;
using System.Threading.Tasks;
using cw_8_ko_xDejw.Models.Medicine.DTOs;
using cw_8_ko_xDejw.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cw_8_ko_xDejw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IMedService _service;
        public PrescriptionsController(IMedService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> GetPrescription(int id)
        {
            var prescription = await _service.GetPrescription(id);
            if(prescription == null) return NotFound();

            var patient = await _service.GetPatientByID(prescription.IdPatient);
            
            
            var patientDto = new Patient{
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthdate = patient.Birthdate
            };
            
            var doctor = await _service.GetDoctorByID(prescription.IdDoctor);

            var doctorDto = new Doctor{
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };

            var prescriptionDto = new Prescription{
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                Patient = patientDto,
                Doctor = doctorDto,
                Medicaments = _service.GetMedicamentsFromPrescription(id).Select(e => new Medicament
                {
                    Name = e.Name,
                    Description = e.Description,
                    Type = e.Type,
                }).ToList()
            };
            

            return Ok(prescriptionDto);
        }

    }
}