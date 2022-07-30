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
using System.Windows.Shapes;

namespace DatenbankFHModell
{
    /// <summary>
    /// Interaktionslogik für Fakultät.xaml
    /// </summary>
    public partial class Fakultät : Window
    {
        DBManager TheDBManager;
        Eventclass TheEvents;


        public Fakultät(DBManager thedbmanager, Eventclass theEvents)
        {
            InitializeComponent();
            TheDBManager = thedbmanager;
            TheEvents = theEvents;
            TheEvents.InsertNewFakultaEntity_requ += Insert_FakultaData;
        }

        private void btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(txt_FakNr.Text, out int id))
            {
                TheDBManager.PushFakultaet(Convert.ToInt32(txt_FakNr.Text), txt_FakName.Text);
                MessageBox.Show("Eingabe war erfolgreich");
                ClearWindow();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Falsche Eingabe!");
            }
        }

        //alter Buttonname
        private void btn_actualice_Click(object sender, RoutedEventArgs e)
        {

        }
        //alter Buttonname
        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {

        }



        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ClearWindow();
        }

        private void ClearWindow()
        {
            txt_FakNr.Text = "";
            txt_FakName.Text = "";
        }

        //Datn an DBManagerübergeben und Löschen
        private void btn_Drop_Click(object sender, RoutedEventArgs e)
        {
            TheDBManager.DeleteFakultaet(Convert.ToInt16(txt_FakNr.Text));
            ClearWindow();

        }

        private void Insert_FakultaData(object sender, Fakultaetentity e)
        {
            txt_FakName.Text = e.Fakultaetname;
            txt_FakNr.Text = Convert.ToString(e.Fakultaetnummer);
        }


        //Daten an DBManager übergeben und überprüfen ob vorhanden, sonst erstellen oder updaten
        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            TheDBManager.Update_Fakultaetname(Convert.ToInt16(txt_FakNr.Text), txt_FakName.Text);
        }
    }
}
