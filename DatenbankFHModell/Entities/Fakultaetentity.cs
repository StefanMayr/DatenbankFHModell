using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankFHModell
{
    public class Fakultaetentity
    {
        public int Fakultaetnummer { get; set; }
        public string Fakultaetname { get; set; }   

        public Fakultaetentity(int _fakultaetnummer, string _fakultaetname)
        {
            Fakultaetnummer = _fakultaetnummer;
            Fakultaetname = _fakultaetname;
        }
    }
}
