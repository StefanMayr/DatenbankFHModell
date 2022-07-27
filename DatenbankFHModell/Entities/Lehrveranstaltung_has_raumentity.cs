using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankFHModell
{
    public  class Lehrveranstaltung_has_raumentity
    {
        public int Lehrveranstaltung_Lehrveranstaltungsnsummer { get; set; }
        public int Raum_Raumnummer { get; set; }
        public int Raum_Gebaeude_Gebaeudenummer { get; set; }

        public Lehrveranstaltung_has_raumentity(int _lehrveranstaltung_Lehrveranstaltungsnsummer,int _raum_Raumnummer, int _raum_Gebaeude_Gebaeudenummer)
        {
            Lehrveranstaltung_Lehrveranstaltungsnsummer = _lehrveranstaltung_Lehrveranstaltungsnsummer;
            Raum_Raumnummer = _raum_Raumnummer;
            Raum_Gebaeude_Gebaeudenummer = _raum_Gebaeude_Gebaeudenummer;
        }
    }
}
