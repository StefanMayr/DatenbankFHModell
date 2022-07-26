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

        public Lehrendeentity()
        {

        }
    }
}
