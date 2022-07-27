using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankFHModell
{
    public class Lehrendeentity
    {
        public int Personalnummer { get; set; }
        public string NameLehrender { get; set; }
        
        public string WohnortLehrender { get; set; }
        public int AlterLehrender { get; set; }
        public string AusbildungLehrender { get; set; }
        public string GeschlechtLehrender { get; set; }
        public int Fakultätnummer { get; set; }

        public Lehrendeentity(int _personalNr, string _name, string _wohnort, int _alter, string _ausbildung, string _geschlecht, int _fakultaetNr)
        {
            Personalnummer = _personalNr;
            NameLehrender = _name;
            WohnortLehrender = _wohnort;
            AlterLehrender = _alter;
            AusbildungLehrender = _ausbildung;
            GeschlechtLehrender = _geschlecht;
            Fakultätnummer = _fakultaetNr;
        }
    }
}
