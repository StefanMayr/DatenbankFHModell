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
        public int Lehrveranstaltung_Lehrveranstaltungsnummer { get; set; }


        public string NameLehrender { get; set; }

        public string Lehrveranstaltungsname { get; set; }
        public DateTime Lehrveranstaltungsdate { get; set; }
        public int Einheit { get; set; }


        public Lehrende_has_Lehrveranstaltungentity(int _lehrende_Personalnummer, int _lehrende_Fakultät_Fakultätnummer, int _lehrveranstaltung_Lehrveranstltungsnummer)
        {
            Lehrende_Personalnummer = _lehrende_Personalnummer;
            Lehrende_Fakultät_Fakultätnummer = _lehrende_Fakultät_Fakultätnummer;
            Lehrveranstaltung_Lehrveranstaltungsnummer = _lehrveranstaltung_Lehrveranstltungsnummer;
        }

        public Lehrende_has_Lehrveranstaltungentity(string _nameLehrender, int _lehrende_Personalnummer, int _lehrveranstaltung_Lehrveranstltungsnummer, string _lehrveranstaltungsname, DateTime _lehrveranstaltungsdate, int _einheit)
        {
            NameLehrender = _nameLehrender;
            Lehrende_Personalnummer = _lehrende_Personalnummer;
            Lehrveranstaltung_Lehrveranstaltungsnummer = _lehrveranstaltung_Lehrveranstltungsnummer;

            Lehrveranstaltungsname = _lehrveranstaltungsname;
            Lehrveranstaltungsdate = _lehrveranstaltungsdate;
            Einheit = _einheit;
        }

    }
}
