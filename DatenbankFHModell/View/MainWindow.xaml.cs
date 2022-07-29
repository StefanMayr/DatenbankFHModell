using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

namespace DatenbankFHModell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        DBManager TheDBManager;
        Eventclass TheEvents;
        public MainWindow(DBManager thedbManager, Eventclass theevents)
        {
            InitializeComponent();
            TheDBManager = thedbManager;
            TheEvents = theevents;

            TheEvents.SendFakultaetDataRequested += InsertFakultaetData;
            TheEvents.SendGebaeudeDataRequested += InsertGebaeudeData;
            TheEvents.SendStudentDataRequested += InsertStudentData;
            TheEvents.SendLehrendenDataRequested += InsertLehrendeData;
            TheEvents.SendLehrveranstaltungDataRequested += InsertLehrveranstaltungsData;
            TheEvents.SendRaumDataRequested += InsertRaumData;
        }

        private void btn_Connect_Click(object sender, RoutedEventArgs e)
        {
            TheDBManager.Connect(Hostname.Text, txt_Server.Text, txt_Databasename.Text, txt_Benutzer.Text, txt_password.Password);
        }

        private void btn_Student_Click(object sender, RoutedEventArgs e)
        {
            TheEvents.SendStartStudent(sender, e);
        }

        private void btn_Fakultät_Click(object sender, RoutedEventArgs e)
        {
            TheEvents.SendStartFakultät(sender, e);
        }

        private void btn_Gebaeude_Click(object sender, RoutedEventArgs e)
        {
            TheEvents.StartGebaeude(sender, e);
        }

        private void btn_Lehrenden_Click(object sender, RoutedEventArgs e)
        {
            TheEvents.StartLehrenden(sender, e);
        }

        private void btn_Lehrveranstaltung_Click(object sender, RoutedEventArgs e)
        {
           // speechSynthesizer.SpeakAsync("yummy");
           TheEvents.StartLehrveranstaltung(sender, e);
        }

        private void btn_Raum_Click(object sender, RoutedEventArgs e)
        {
            TheEvents.StartRaum(sender, e);
        }

        private void btn_Fakultät_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TheEvents.DownloadFakultaetData(sender, e);
        }

        private void btn_Gebaeude_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TheEvents.DownloadGebaeudeData(sender, e);
        }

        private void btn_Student_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TheEvents.DownloadStudentData(sender, e);
        }

        private void btn_Lehrende_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TheEvents.DownloadLehrendeData(sender, e);
        }

        private void btn_Lehrveranstaltung_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TheEvents.DownloadLehrveranstaltungData(sender, e);
        }

        private void btn_Raum_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TheEvents.DownloadRaumData(sender, e);
        }

        private void InsertFakultaetData(object sender, List<Fakultaetentity> list)
        {
            Grid_MainDataGrid.Columns.Clear();
            AddColumnatRuntime("Fakultaetnummer", "Fakultaetnummer");
            AddColumnatRuntime("Fakultaetname", "Fakultaetname");
            foreach(Fakultaetentity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
        }

        private void InsertGebaeudeData(object sender, List<Gebaeudeentity> list)
        {
            Grid_MainDataGrid.Columns.Clear();
            AddColumnatRuntime("Gebaeudenummer", "Gebaeudenummer");
            foreach (Gebaeudeentity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
        }

        private void InsertStudentData(object sender, List<Studententity> list)
        {
            Grid_MainDataGrid.Columns.Clear();
            AddColumnatRuntime("Matrikelnummer", "Matrikelnummer");
            AddColumnatRuntime("Name", "Studentname");
            AddColumnatRuntime("Wohnort", "StudentWohnort");
            AddColumnatRuntime("Geschlecht", "StudentGeschlecht");
            AddColumnatRuntime("Alter", "StudentAlter");
            foreach(Studententity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
        }

        private void InsertLehrendeData(object sender, List<Lehrendeentity> list)
        {
            Grid_MainDataGrid.Columns.Clear();
            AddColumnatRuntime("Personalnummer", "Personalnummer");
            AddColumnatRuntime("Name", "NameLehrender");
            AddColumnatRuntime("Wohnort", "WohnortLehrender");
            AddColumnatRuntime("Alter", "AlterLehrender");
            AddColumnatRuntime("Ausbildung", "AusbildungLehrender");
            AddColumnatRuntime("Geschlecht", "GeschlechtLehrender");
            AddColumnatRuntime("Fakultät", "Fakultätnummer");
            foreach(Lehrendeentity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
        }

        private void InsertLehrveranstaltungsData(object sender, List<Lehrveranstaltungentity> list)
        {
            Grid_MainDataGrid.Columns.Clear();
            AddColumnatRuntime("Lehrveranstaltungsnummer", "Lehrveranstaltungsnummer");
            AddColumnatRuntime("Lehrveranstaltungsname", "Lehrveranstaltungsname");
            AddColumnatRuntime("Datum", "Lehrveranstaltungsdate");
            AddColumnatRuntime("Einheit", "Einheit");
            foreach (Lehrveranstaltungentity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
        }

        private void InsertRaumData(object sender, List<Raumentity> list)
        {
            Grid_MainDataGrid.Columns.Clear();
            AddColumnatRuntime("Raumnummer", "Raumnummer");
            AddColumnatRuntime("Gebäudenummer", "Gebaeudenummer");
            foreach (Raumentity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
        }

        private void AddColumnatRuntime(string _header, string _binding)
        {
            Grid_MainDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = _header,
                Binding = new Binding(_binding)
            });
        }

        private void btn_Student_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void btn_Student_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btn_Student_has_Lehrveranstaltung_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Student_has_Lehrveranstaltung_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            List<Student_has_Lehrveranstaltungentity> list = TheDBManager.PullStudent_has_Lehrveranstaltung();
            Grid_MainDataGrid.Columns.Clear();
            AddColumnatRuntime("Matrikelnummer", "Student_Matrikelnummer");
            AddColumnatRuntime("Name", "Studentname");
            AddColumnatRuntime("Lehrveranstaltungsnummer", "Lehrveranstaltung_Lehrveranstaltungsnummer");
            AddColumnatRuntime("Lehrveranstaltungsname", "Lehrveranstaltungsname");
            AddColumnatRuntime("Lehrveranstaltungsdatum", "Lehrveranstaltungsdate");
            AddColumnatRuntime("Einheit", "Einheit");

            foreach(Student_has_Lehrveranstaltungentity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
        }

        private void btn_Lehrende_has_Lehrveranstaltung_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Lehrende_has_Lehrveranstaltung_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            List<Lehrende_has_Lehrveranstaltungentity> list = TheDBManager.PullLehrende_has_Lehrveranstaltungentity();
            Grid_MainDataGrid.Columns.Clear();
            AddColumnatRuntime("Personalnummer", "Lehrende_Personalnummer");
            AddColumnatRuntime("Name", "NameLehrender");
            AddColumnatRuntime("Lehrveranstaltungsnummer", "Lehrveranstaltung_Lehrveranstaltungsnummer");
            AddColumnatRuntime("Lehrveranstaltungsname", "Lehrveranstaltungsname");
            AddColumnatRuntime("Lehrveranstaltungsdatum", "Lehrveranstaltungsdate");
            AddColumnatRuntime("Einheit", "Einheit");

            foreach (Lehrende_has_Lehrveranstaltungentity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
        }
    }
}
