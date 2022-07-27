using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankFHModell
{
    public class Lehrende_has_Lehrveranstaltungentity
    {
        public int Lehrende_Personalnummer { get; set; }
        public int Lehrende_Fakultät_Fakultätnummer { get; set; }
        public int Lehrveranstaltung_Lehrveranstltungsnummer { get; set; }

        public Lehrende_has_Lehrveranstaltungentity(int _lehrende_Personalnummer, int _lehrende_Fakultät_Fakultätnummer, int _lehrveranstaltung_Lehrveranstltungsnummer)
        {
            Lehrende_Personalnummer = _lehrende_Personalnummer;
            Lehrende_Fakultät_Fakultätnummer = _lehrende_Fakultät_Fakultätnummer;
            Lehrveranstaltung_Lehrveranstltungsnummer = _lehrveranstaltung_Lehrveranstltungsnummer;
        }
    }
}
