using System.Collections.Generic;
using System.Threading.Tasks;
using cw_8_ko_xDejw.Models.Medicine;


namespace cw_8_ko_xDejw.Services
{
    public interface IMedService
    {
         public Task<Doctor> GetDoctorByID(int id);
         public Task<Patient> GetPatientByID(int id);
         public Task<Prescription> GetPrescription(int id);
         public IEnumerable<Medicament> GetMedicamentsFromPrescription(int id);
         public Task AddDoctor(Models.Medicine.DTOs.Doctor data);
         public void DeleteDoctor(Doctor data);
         public Task SaveDatabase();
    }
}