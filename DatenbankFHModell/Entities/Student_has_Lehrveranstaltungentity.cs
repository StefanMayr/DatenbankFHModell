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


        public string Studentname { get; set; }
        public string Lehrveranstaltungsname { get; set; }
        public DateTime Lehrveranstaltungsdate { get; set; }
        public int Einheit { get; set; }

        public Student_has_Lehrveranstaltungentity(int _student_Matrikelnummer, int _lehrveranstaltung_Lehrveranstaltungsnummer)
        {
            Student_Matrikelnummer = _student_Matrikelnummer;
            Lehrveranstaltung_Lehrveranstaltungsnummer = _lehrveranstaltung_Lehrveranstaltungsnummer;
        }

        public Student_has_Lehrveranstaltungentity(string _studentname, int _student_Matrikelnummer, int _lehrveranstaltung_Lehrveranstaltungsnummer, string _lehrveranstaltungsname, DateTime _lehrveranstaltungsdate, int _einheit)
        {
            Studentname = _studentname;
            Student_Matrikelnummer = _student_Matrikelnummer;
            Lehrveranstaltung_Lehrveranstaltungsnummer = _lehrveranstaltung_Lehrveranstaltungsnummer;

            Lehrveranstaltungsname = _lehrveranstaltungsname;
            Lehrveranstaltungsdate = _lehrveranstaltungsdate;
            Einheit = _einheit;
        }
    }
}
