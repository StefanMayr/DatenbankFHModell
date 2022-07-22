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
        Fakultät TheFakultätPage;
        Gebaeude TheGebaeudePage;
        Lehrendeclass TheLehrendenPage;

        public Presenter(Eventclass theevents, DBManager thedbmanager, MainWindow themainwindow, Student thestudentpage, Fakultät thefakultät, Gebaeude thegebaeudepage, Lehrendeclass thelehrendenpage)
        {
            TheDBManager = thedbmanager;
            TheStudentPAge = thestudentpage;
            TheFakultätPage = thefakultät;
            TheGebaeudePage = thegebaeudepage;
            TheLehrendenPage = thelehrendenpage;

            TheEvent = theevents;
            MainWindow = themainwindow;

            TheEvent.StartStudentRequested += StartStudentPage;
            TheEvent.StartFakultätRequested += StartFakultät;
            TheEvent.StartGebaeudeRequested += StartGebaeude;
            TheEvent.StartLehrendenRequested += StartLehrenden;
        }

        private void StartStudentPage(object sender, EventArgs e)
        {
            TheStudentPAge.ShowDialog();
        }

        private void StartFakultät(object sender, EventArgs e)
        {
            TheFakultätPage.ShowDialog();
        }

        private void StartGebaeude(object sender, EventArgs e)
        {
            TheGebaeudePage.ShowDialog();
        }

        private void StartLehrenden(object sender, EventArgs e)
        {
            TheLehrendenPage.ShowDialog();
        }
    }
}
