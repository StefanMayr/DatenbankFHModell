using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankFHModell
{
    public class Lehrveranstaltungentity
    {
        public int Lehrveranstaltungsnummer { get; set; }
        public string Lehrveranstaltungsname { get; set; }
        public DateTime Lehrveranstaltungsdate { get; set; }
        public int Einheit { get; set; }
        public Lehrveranstaltungentity()
        {

        }
    }
}
