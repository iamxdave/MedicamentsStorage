using System.Collections.Generic;

namespace cw_8_ko_xDejw.Models.Medicine
{
    public class Medicament
    {
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public virtual IEnumerable<Prescription_Medicament> Prescription_Medicaments { get; set; }
    }
}