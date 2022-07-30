using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankFHModell
{
    public class Eventclass
    {
        //Start Pages
        public event EventHandler StartStudentRequested;
        public event EventHandler StartFakultätRequested;
        public event EventHandler StartGebaeudeRequested;
        public event EventHandler StartLehrendenRequested;
        public event EventHandler StartLehhrveranstaltungpageRequested;
        public event EventHandler StartRaumpageRequested;
        public event EventHandler StartLehrveranstaltungRequested;
        public event EventHandler StartStudent_has_LRequested;
        public event EventHandler StartLehrende_has_LRequested;
        public event EventHandler StartLehrv_has_RRequested;

        //Download Data
        public event EventHandler DownloadFakultaetDataRequested;
        public event EventHandler<List<Fakultaetentity>> SendFakultaetDataRequested;
        public event EventHandler DownloadGebaeudeDataRequested;
        public event EventHandler<List<Gebaeudeentity>> SendGebaeudeDataRequested;
        public event EventHandler DownloadStudentDataRequested;
        public event EventHandler<List<Studententity>> SendStudentDataRequested;
        public event EventHandler DownloadLehrendenDataRequested;
        public event EventHandler<List<Lehrendeentity>> SendLehrendenDataRequested;
        public event EventHandler DownloadLehrveranstaltungDataRequested;
        public event EventHandler<List<Lehrveranstaltungentity>> SendLehrveranstaltungDataRequested;
        public event EventHandler DownloadRaumDataRequested;
        public event EventHandler<List<Raumentity>> SendRaumDataRequested;
        public event EventHandler DownloadStudent_has_LehrveranstaltungDataRequested;
        public event EventHandler<List<Student_has_Lehrveranstaltungentity>> SendStudent_has_LehrveranstaltungDataRequested;
        public event EventHandler DownloadLehrende_has_LehrveranstaltungDataRequested;
        public event EventHandler<List<Lehrende_has_Lehrveranstaltungentity>> SendLehrende_has_LehrveranstaltungDataRequested;
        public event EventHandler DownloadLehrveranstaltung_has_RaumDataRequested;
        public event EventHandler<List<Lehrveranstaltung_has_raumentity>> SendLehrveranstaltung_has_RaumDataRequested;

        //Daten in Fenster laden
        public event EventHandler<Fakultaetentity> LoadFakultaEntityRequested;
        public event EventHandler<Fakultaetentity> InsertNewFakultaEntity_requ;
        


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

        public void DownloadFakultaetData(object sender, EventArgs e)
        {
            DownloadFakultaetDataRequested(sender, e);
        }

        public void SendFakultaetData(object sender, List<Fakultaetentity> List)
        {
            SendFakultaetDataRequested(sender, List);
        }

        public void DownloadGebaeudeData(object sender, EventArgs e)
        {
            DownloadGebaeudeDataRequested(sender, e);
        }

        public void SendGebaeudeData(object sender, List<Gebaeudeentity> List)
        {
            SendGebaeudeDataRequested(sender, List);
        }

        public void DownloadStudentData(object sender, EventArgs e)
        {
            DownloadStudentDataRequested(sender, e);
        }

        public void SendStudentData(object sender, List<Studententity> list)
        {
            SendStudentDataRequested(sender, list);
        }

        public void DownloadLehrendeData(object sender, EventArgs e)
        {
            DownloadLehrendenDataRequested(sender, e);
        }

        public void SendLehrendeData(object sender, List<Lehrendeentity> list)
        {
            SendLehrendenDataRequested(sender, list);
        }

        public void DownloadLehrveranstaltungData(object sender, EventArgs e)
        {
            DownloadLehrveranstaltungDataRequested(sender, e);
        }

        public void SendLehrveranstaltungData(object sender, List<Lehrveranstaltungentity> list)
        {
            SendLehrveranstaltungDataRequested(sender, list);
        }

        public void DownloadRaumData(object sender, EventArgs e)
        {
            DownloadRaumDataRequested(sender, e);
        }

        public void SendRaumData(object sender, List<Raumentity> list)
        {
            SendRaumDataRequested(sender, list);
        }

        public void DownloadStudent_has_LehrveranstaltungData(object sender, EventArgs e)
        {
            DownloadStudent_has_LehrveranstaltungDataRequested(sender, e);
        }

        public void SendStudent_has_LehrveranstaltungData(object sender, List<Student_has_Lehrveranstaltungentity> list)
        {
            SendStudent_has_LehrveranstaltungDataRequested(sender, list);
        }

        public void DownloadLehrende_has_LehrveranstaltungData(object sender, EventArgs e)
        {
            DownloadLehrende_has_LehrveranstaltungDataRequested(sender, e);
        }

        public void SendLehrende_has_LehrveranstaltungData(object sender, List<Lehrende_has_Lehrveranstaltungentity> list)
        {
            SendLehrende_has_LehrveranstaltungDataRequested(sender, list);
        }

        public void DownloadLehrveranstaltung_has_RaumData(object sender, EventArgs e)
        {
            DownloadLehrveranstaltung_has_RaumDataRequested(sender, e);
        }

        public void SendLehrveranstaltung_has_RaumData(object sender, List<Lehrveranstaltung_has_raumentity> list)
        {
            SendLehrveranstaltung_has_RaumDataRequested(sender, list);
        }

        public void StartStudent_has_L(object sender, EventArgs e)
        {
            StartStudent_has_LRequested(sender, e);
        }

        public void StartLehrende_has_L(object sender, EventArgs e)
        {
            StartLehrende_has_LRequested(sender, e);
        }

        public void StartLehrv_has_R(object sender, EventArgs e)
        {
            StartLehrv_has_RRequested(sender, e);
        }

        public void LoadFakultaEntity(object sender, Fakultaetentity e)
        {
            LoadFakultaEntityRequested(sender, e);
        }

        public void InsertNewFakultaEntity(object sender, Fakultaetentity e)
        {
            InsertNewFakultaEntity_requ(sender, e); 
        }
    }
}
