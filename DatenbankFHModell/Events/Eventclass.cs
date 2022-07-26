using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankFHModell
{
    public class Eventclass
    {
        //Student
        public event EventHandler StartStudentRequested;

        //Fakultät
        public event EventHandler StartFakultätRequested;

        //Gebaude
        public event EventHandler StartGebaeudeRequested;

        //Lehrenden
        public event EventHandler StartLehrendenRequested;

        //Lehrveranstaltung
        public event EventHandler StartLehrveranstaltungRequested;

        public void SendStartStudent(object sender, EventArgs e)
        {
            StartStudentRequested(sender, e);
        }

        public void SendStartFakultät(object sender, EventArgs e)
        {
            StartFakultätRequested(sender, e);
        }

        public void StartGebaeude(object sender, EventArgs e)
        {
            StartGebaeudeRequested(sender, e);
        }

        public void StartLehrenden(object sender, EventArgs e)
        {
            StartLehrendenRequested(sender, e);
        }

        public void StartLehrveranstaltung(object sender, EventArgs e)
        {
            StartLehrveranstaltungRequested(sender, e);
        }
    }
}
