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
        public int Lehrnede_Fakultät_Fakultätnummer { get; set; }
        public int Lehrveranstaltung_Lehrveranstltungsnummer { get; set; }

        public Lehrende_has_Lehrveranstaltungentity()
        {

        }
    }
}
