using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankFHModell
{
    public class Eventclass
    {
        //Start 
        public event EventHandler StartStudentRequested;
        public event EventHandler StartFakultätRequested;
        public event EventHandler StartGebaeudeRequested;
        public event EventHandler StartLehrendenRequested;
        public event EventHandler StartLehhrveranstaltungpageRequested;
        public event EventHandler StartRaumpageRequested;

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
            StartLehhrveranstaltungpageRequested(sender, e);
        }

        public void StartRaum(object sender, EventArgs e)
        {
            StartRaumpageRequested(sender, e);
        }
    }
}
