using System;
using System.Collections.Generic;

namespace cw_8_ko_xDejw.Models.Medicine
{
    public class Patient
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual IEnumerable<Prescription> Prescriptions { get; set; }
    }
}