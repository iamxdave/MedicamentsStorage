using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw_8_ko_xDejw.Models;
using cw_8_ko_xDejw.Models.Medicine;
using Microsoft.EntityFrameworkCore;

namespace cw_8_ko_xDejw.Services
{
    public class MedService : IMedService
    {
        private readonly MedDbContext _context;
        public MedService(MedDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> GetDoctorByID(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(e => e.IdDoctor == id);
        }

        public async Task<Patient> GetPatientByID(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(e => e.IdPatient == id);
        }

        public async Task<Prescription> GetPrescription(int id)
        {
            return await _context.Prescriptions
                .FirstOrDefaultAsync(e => e.IdPrescription == id);
        }

        public IEnumerable<Medicament> GetMedicamentsFromPrescription(int id)
        {
            var ids = _context.Prescription_Medicaments.Where(e => e.IdPrescription == id).Select(e => e.IdMedicament);
            return _context.Medicaments.Where(e => ids.Contains(e.IdMedicament));
        }

        public async Task AddDoctor(Models.Medicine.DTOs.Doctor data)
        {
            var doctor = new Doctor{
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email
            };

            await _context.AddAsync(doctor);
        }

        public void DeleteDoctor(Doctor data)
        {
            var entry = _context.Entry(data);
            entry.State = EntityState.Deleted;
        }

        public async Task SaveDatabase()
        {
            await _context.SaveChangesAsync();
        }


    }
}