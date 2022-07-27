using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankFHModell
{
    public class Gebaeudeentity
    {
        public int Gebaeudenummer { get; set; }
        public Gebaeudeentity(int _gebaeudenummer)
        {
            Gebaeudenummer = _gebaeudenummer;
        }
    }
}
