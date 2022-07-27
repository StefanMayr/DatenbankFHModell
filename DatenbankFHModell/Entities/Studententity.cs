using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankFHModell
{
    public class Studententity
    {
        public int Matrikelnummer { get; set; }
        public string Studentname { get; set; }
        public string StudentWohnort { get; set; }
        public string StudentGeschlecht { get; set; }
        public int StudentAlter { get; set; }
        public Studententity(int _matrikelnummer, string _studentname, string _studentWohnort, string _studentGeschlecht, int _studentAlter)
        {
            Matrikelnummer = _matrikelnummer;
            Studentname = _studentname;
            StudentWohnort = _studentWohnort;
            StudentGeschlecht = _studentGeschlecht;
            StudentAlter = _studentAlter;
        }
    }
}
