using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankFHModell
{
    public class Raumentity
    {
        public int Raumnummer { get; set; }
        public int Gebaeudenummer { get; set; }
        public Raumentity(int _raumnummer, int _gebaeudenummer)
        {
            Raumnummer = _raumnummer;
            Gebaeudenummer = _gebaeudenummer;
        }
    }
}
