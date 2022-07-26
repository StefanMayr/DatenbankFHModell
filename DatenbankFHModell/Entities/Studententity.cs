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
        public Studententity()
        {

        }
    }
}
