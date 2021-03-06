using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
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
        char chooseChangeType = '0';
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
            TheEvents.SendStudent_has_LehrveranstaltungDataRequested += InsertStudent_has_Lehrveranstaltung;
            TheEvents.SendLehrende_has_LehrveranstaltungDataRequested += InsertLehrende_has_Lehrveranstaltung;
            TheEvents.SendLehrveranstaltung_has_RaumDataRequested += InsertLehrveranstaltung_has_raum;
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
            Grid_MainDataGrid.Items.Clear();
            AddColumnatRuntime("Fakultaetnummer", "Fakultaetnummer");
            AddColumnatRuntime("Fakultaetname", "Fakultaetname");
            foreach(Fakultaetentity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
            chooseChangeType = '1';
        }

        private void InsertGebaeudeData(object sender, List<Gebaeudeentity> list)
        {
            Grid_MainDataGrid.Columns.Clear();
            Grid_MainDataGrid.Items.Clear();
            AddColumnatRuntime("Gebaeudenummer", "Gebaeudenummer");
            foreach (Gebaeudeentity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
            chooseChangeType = '2';
        }

        private void InsertStudentData(object sender, List<Studententity> list)
        {
            Grid_MainDataGrid.Columns.Clear();
            Grid_MainDataGrid.Items.Clear();
            AddColumnatRuntime("Matrikelnummer", "Matrikelnummer");
            AddColumnatRuntime("Name", "Studentname");
            AddColumnatRuntime("Wohnort", "StudentWohnort");
            AddColumnatRuntime("Geschlecht", "StudentGeschlecht");
            AddColumnatRuntime("Alter", "StudentAlter");
            foreach(Studententity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
            chooseChangeType = '3';
        }

        private void InsertLehrendeData(object sender, List<Lehrendeentity> list)
        {
            Grid_MainDataGrid.Columns.Clear();
            Grid_MainDataGrid.Items.Clear();
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
            chooseChangeType = '4';
        }

        private void InsertLehrveranstaltungsData(object sender, List<Lehrveranstaltungentity> list)
        {
            Grid_MainDataGrid.Columns.Clear();
            Grid_MainDataGrid.Items.Clear();
            AddColumnatRuntime("Lehrveranstaltungsnummer", "Lehrveranstaltungsnummer");
            AddColumnatRuntime("Lehrveranstaltungsname", "Lehrveranstaltungsname");
            AddColumnatRuntime("Datum", "Lehrveranstaltungsdate");
            AddColumnatRuntime("Einheit", "Einheit");
            foreach (Lehrveranstaltungentity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
            chooseChangeType = '5';
        }

        private void InsertRaumData(object sender, List<Raumentity> list)
        {
            Grid_MainDataGrid.Columns.Clear();
            Grid_MainDataGrid.Items.Clear();
            AddColumnatRuntime("Raumnummer", "Raumnummer");
            AddColumnatRuntime("Gebäudenummer", "Gebaeudenummer");
            foreach (Raumentity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
            chooseChangeType = '6';
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
            TheEvents.StartStudent_has_L(sender, e);
        }

        private void btn_Student_has_Lehrveranstaltung_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TheEvents.DownloadStudent_has_LehrveranstaltungData(sender, e);
        }

        private void InsertStudent_has_Lehrveranstaltung(object sender, List<Student_has_Lehrveranstaltungentity> list)
        {
            Grid_MainDataGrid.Columns.Clear();
            Grid_MainDataGrid.Items.Clear();
            AddColumnatRuntime("Matrikelnummer", "Student_Matrikelnummer");
            AddColumnatRuntime("Name", "Studentname");
            AddColumnatRuntime("Lehrveranstaltungsnummer", "Lehrveranstaltung_Lehrveranstaltungsnummer");
            AddColumnatRuntime("Lehrveranstaltungsname", "Lehrveranstaltungsname");
            AddColumnatRuntime("Lehrveranstaltungsdatum", "Lehrveranstaltungsdate");
            AddColumnatRuntime("Einheit", "Einheit");

            foreach (Student_has_Lehrveranstaltungentity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
        }

        private void btn_Lehrende_has_Lehrveranstaltung_Click(object sender, RoutedEventArgs e)
        {
            TheEvents.StartLehrende_has_L(sender, e);
        }

        private void btn_Lehrende_has_Lehrveranstaltung_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TheEvents.DownloadLehrende_has_LehrveranstaltungData(sender, e);
        }

        private void InsertLehrende_has_Lehrveranstaltung(object sender, List<Lehrende_has_Lehrveranstaltungentity> list)
        {
            Grid_MainDataGrid.Columns.Clear();
            Grid_MainDataGrid.Items.Clear();
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

        private void btn_Lehrveranstaltung_has_raum_Click(object sender, RoutedEventArgs e)
        {
            TheEvents.StartLehrv_has_R(sender, e);
        }

        private void btn_Lehrveranstaltung_has_raum_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TheEvents.DownloadLehrveranstaltungData(sender, e);
        }

        private void InsertLehrveranstaltung_has_raum(object sender, List<Lehrveranstaltung_has_raumentity> list)
        {
            Grid_MainDataGrid.Columns.Clear();
            Grid_MainDataGrid.Items.Clear();
            AddColumnatRuntime("Lehrveranstaltungsnsummer", "Lehrveranstaltung_Lehrveranstaltungsnsummer");
            AddColumnatRuntime("Lehrveranstaltungsname", "Lehrveranstaltungsname");
            AddColumnatRuntime("Lehrveranstaltungsdate", "Lehrveranstaltungsdate");
            AddColumnatRuntime("Einheit", "Einheit");
            AddColumnatRuntime("Raumnummer", "Raum_Raumnummer");
            AddColumnatRuntime("Gebaeudenummer", "Raum_Gebaeude_Gebaeudenummer");

            foreach (Lehrveranstaltung_has_raumentity item in list)
            {
                Grid_MainDataGrid.Items.Add(item);
            }
        }

        private void btn_Bearbeiten_Click(object sender, RoutedEventArgs e)
        {

            chooseChangeType = this.chooseChangeType;

            switch (chooseChangeType)
            {
                case '1':
                    {
                        Fakultaetentity fak = Grid_MainDataGrid.SelectedItem as Fakultaetentity;
                        List<Fakultaetentity> fakList = new List<Fakultaetentity>();
                        fakList.Add(fak);
                        TheEvents.LoadFakultaEntity(sender, fak);
                        TheEvents.SendStartFakultät(sender, e);
                        TheEvents.DownloadFakultaetData(sender, e);
                        break;
                    }
                case '2':
                    {
                        Gebaeudeentity gebaeu = Grid_MainDataGrid.SelectedItem as Gebaeudeentity; ;
                        List<Gebaeudeentity> gebaeuList = new List<Gebaeudeentity>();
                        gebaeuList.Add(gebaeu);
                        TheEvents.LoadGebaeudeEntity(sender, gebaeu);
                        TheEvents.StartGebaeude(sender, e);
                        TheEvents.DownloadGebaeudeData(sender, e);
                        break;
                    }
                case '3':
                    {
                        Studententity student = Grid_MainDataGrid.SelectedItem as Studententity; ;
                        List<Studententity> studentList = new List<Studententity>();
                        studentList.Add(student);
                        TheEvents.LoadStudentEntity(sender, student);
                        TheEvents.SendStartStudent(sender, e);
                        TheEvents.DownloadStudentData(sender, e);
                        break;
                    }
                case '4':
                    {
                        Lehrendeentity lehrende = Grid_MainDataGrid.SelectedItem as Lehrendeentity; ;
                        List<Lehrendeentity> lehrendeList = new List<Lehrendeentity>();
                        lehrendeList.Add(lehrende);
                        TheEvents.LoadLehrendeEntity(sender, lehrende);
                        TheEvents.StartLehrenden(sender, e);
                        TheEvents.DownloadLehrendeData(sender, e);
                        break;
                    }
                case '5':
                    {
                        Lehrveranstaltungentity lehrveranstaltung = Grid_MainDataGrid.SelectedItem as Lehrveranstaltungentity; ;
                        List<Lehrveranstaltungentity> lehrveranstaltungList = new List<Lehrveranstaltungentity>();
                        lehrveranstaltungList.Add(lehrveranstaltung);
                        TheEvents.LoadLehrveranstaltungEntity(sender, lehrveranstaltung);
                        TheEvents.StartLehrveranstaltung(sender, e);
                        TheEvents.DownloadLehrveranstaltungData(sender, e);
                        break;
                    }
                case '6':
                    {
                        Raumentity raum = Grid_MainDataGrid.SelectedItem as Raumentity; ;
                        List<Raumentity> raumList = new List<Raumentity>();
                        raumList.Add(raum);
                        TheEvents.LoadRaumEntity(sender, raum);
                        TheEvents.StartRaum(sender, e);
                        TheEvents.DownloadRaumData(sender, e);
                        break;
                    }
            }
        }
    }
}
