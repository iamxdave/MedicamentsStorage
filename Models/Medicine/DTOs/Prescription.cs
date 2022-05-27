using System;
using System.Collections.Generic;

namespace cw_8_ko_xDejw.Models.Medicine.DTOs
{
    public class Prescription
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual List<Medicament> Medicaments { get; set; }
    }

    public class Medicament
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}