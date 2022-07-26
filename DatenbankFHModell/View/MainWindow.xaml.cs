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

        private void AddColumnatRuntime(string _header, string _binding)
        {
            Grid_MainDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = _header,
                Binding = new Binding(_binding)
            });
        }
    }
}
