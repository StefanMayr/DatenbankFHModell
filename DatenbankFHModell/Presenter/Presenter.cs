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
        Lehrveranstaltungsclass TheLehrveranstaltungsclassPage;
        Raum TheRaumpage;

        public Presenter(Eventclass theevents, DBManager thedbmanager, MainWindow themainwindow, Student thestudentpage, Fakultät thefakultät, Gebaeude thegebaeudepage, Lehrendeclass thelehrendenpage, Lehrveranstaltungsclass thelehrveranstaltungspage, Raum theraumpage)
        {
            TheDBManager = thedbmanager;
            TheStudentPAge = thestudentpage;
            TheFakultätPage = thefakultät;
            TheGebaeudePage = thegebaeudepage;
            TheLehrendenPage = thelehrendenpage;
            TheLehrveranstaltungsclassPage = thelehrveranstaltungspage;
            TheRaumpage = theraumpage;

            TheEvent = theevents;
            MainWindow = themainwindow;

            TheEvent.StartStudentRequested += StartStudentPage;
            TheEvent.StartFakultätRequested += StartFakultät;
            TheEvent.StartGebaeudeRequested += StartGebaeude;
            TheEvent.StartLehrendenRequested += StartLehrenden;
            TheEvent.StartLehhrveranstaltungpageRequested += StartLehrveranstaltung;
            TheEvent.StartRaumpageRequested += StartRaumpage;
            TheEvent.DownloadFakultaetDataRequested += DownloadFakultaetData;
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

        private void StartLehrveranstaltung(object sender, EventArgs e)
        {
            TheLehrveranstaltungsclassPage.ShowDialog();
        }

        private void StartRaumpage(object sender, EventArgs e)
        {
            TheRaumpage.ShowDialog();
        }

        private void DownloadFakultaetData(object sender, EventArgs e)
        {
            List<Fakultaetentity> list = TheDBManager.PullFakultaet();
            TheEvent.SendFakultaetData(sender, list);
        }
    }
}
