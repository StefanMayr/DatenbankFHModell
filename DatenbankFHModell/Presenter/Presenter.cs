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
            TheEvent.DownloadGebaeudeDataRequested += DownloadGebaeudeData;
            TheEvent.DownloadStudentDataRequested += DownloadStudentData;
            TheEvent.DownloadLehrendenDataRequested += DownloadLehrendeData;
            TheEvent.DownloadLehrveranstaltungDataRequested += DownloadLehrveranstaltungData;
            TheEvent.DownloadRaumDataRequested += DownloadRaumData;
            TheEvent.DownloadStudent_has_LehrveranstaltungDataRequested += DownloadStudent_has_LehrveranstaltungsData;
            TheEvent.DownloadLehrende_has_LehrveranstaltungDataRequested += DownloadLehrende_has_LehrveranstaltungsData;
            TheEvent.DownloadLehrveranstaltung_has_RaumDataRequested += DownloadLehrveranstaltung_has_raumData;
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

        private void DownloadGebaeudeData(object sender, EventArgs e)
        {
            List<Gebaeudeentity> list = TheDBManager.PullGebaeude();
            TheEvent.SendGebaeudeData(sender, list);
        }

        private void DownloadStudentData(object sender, EventArgs e)
        {
            List<Studententity> list = TheDBManager.PullStudent();
            TheEvent.SendStudentData(sender, list);
        }

        private void DownloadLehrendeData(object sender, EventArgs e)
        {
            List <Lehrendeentity> list = TheDBManager.PullLehrende();
            TheEvent.SendLehrendeData(sender, list);
        }

        private void DownloadLehrveranstaltungData(object sender, EventArgs e)
        {
            List<Lehrveranstaltungentity> list = TheDBManager.PullLehrveranstaltung();
            TheEvent.SendLehrveranstaltungData(sender, list);
        }

        private void DownloadRaumData(object sender, EventArgs e)
        {
            List<Raumentity> list = TheDBManager.PullRaum();
            TheEvent.SendRaumData(sender, list);
        }

        private void DownloadStudent_has_LehrveranstaltungsData(object sender, EventArgs e)
        {
            List<Student_has_Lehrveranstaltungentity> list = TheDBManager.PullStudent_has_Lehrveranstaltung();
            TheEvent.SendStudent_has_LehrveranstaltungData(sender, list);
        }

        private void DownloadLehrende_has_LehrveranstaltungsData(object sender, EventArgs e)
        {
            List<Lehrende_has_Lehrveranstaltungentity> list = TheDBManager.PullLehrende_has_Lehrveranstaltungentity();
            TheEvent.SendLehrende_has_LehrveranstaltungData(sender, list);
        }

        private void DownloadLehrveranstaltung_has_raumData(object sender, EventArgs e)
        {
            List<Lehrveranstaltung_has_raumentity> list = TheDBManager.PullLehrveranstaltung_has_raumentity();
            TheEvent.SendLehrveranstaltung_has_RaumData(sender, list);
        }
    }
}
