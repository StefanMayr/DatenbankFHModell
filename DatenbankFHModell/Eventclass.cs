using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankFHModell
{
    public class Eventclass
    {
        public event EventHandler SendStartStudentCommandRequested;
        public event EventHandler SendEndStudentCommandRequested;
        public event EventHandler StartStudendRequested;

        public void SendStartStudent(object sender, EventArgs e)
        {
            SendStartStudentCommandRequested(sender, e);
        }

        public void StartStudent(object sender, EventArgs e)
        {
            StartStudendRequested(sender, e);
        }
    }
}
