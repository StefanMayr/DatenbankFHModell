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
        public Lehrveranstaltungentity(int _lehrveranstaltungsnummer, string _lehrveranstaltungsname, DateTime _lehrveranstaltungsdate, int _einheit)
        {
            Lehrveranstaltungsnummer = _lehrveranstaltungsnummer;
            Lehrveranstaltungsname = _lehrveranstaltungsname;
            Lehrveranstaltungsdate = _lehrveranstaltungsdate;
            Einheit = _einheit;
        }
    }
}
