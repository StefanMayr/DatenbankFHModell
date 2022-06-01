using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankFHModell
{
    public class Presenter
    {
        Eventclass TheEvent;
        DBManager TheDBManager;

        MainWindow MainWindow;
        Student TheStudentPAge;
        public Presenter(Eventclass theevents, DBManager thedbmanager, MainWindow themainwindow, Student thestudentpage)
        {
            TheDBManager = thedbmanager;
            TheStudentPAge = thestudentpage;
            TheEvent = theevents;
            MainWindow = themainwindow;

            TheEvent.SendStartStudentCommandRequested += StartStudentPage;
        }

        private void StartStudentPage(object sender, EventArgs e)
        {
            TheStudentPAge.ShowDialog();
        }
    }
}
