using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankFHModell
{
    public class Student_has_Lehrveranstaltungentity
    {
        public int Student_Matrikelnummer { get; set; }
        public int Lehrveranstaltung_Lehrveranstaltungsnummer { get; set; }

        public Student_has_Lehrveranstaltungentity(int _student_Matrikelnummer, int _lehrveranstaltung_Lehrveranstaltungsnummer)
        {
            Student_Matrikelnummer = _student_Matrikelnummer;
            Lehrveranstaltung_Lehrveranstaltungsnummer = _lehrveranstaltung_Lehrveranstaltungsnummer;
        }
    }
}
