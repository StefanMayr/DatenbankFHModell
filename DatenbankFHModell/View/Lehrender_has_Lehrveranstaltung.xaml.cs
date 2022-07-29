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
    /// Interaktionslogik für Lehrender_has_Lehrveranstaltung.xaml
    /// </summary>
    public partial class Lehrender_has_Lehrveranstaltung : Window
    {
        DBManager TheDBManager;
        public Lehrender_has_Lehrveranstaltung(DBManager thedbmanager)
        {
            InitializeComponent();
            TheDBManager = thedbmanager;
        }

        private void btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txt_Lehrveranstaltungsnummer.Text, out int id) && int.TryParse(txt_Personalnummer.Text, out int id2) && int.TryParse(txt_Fakultaetsnummer.Text, out int id3))
            {
                TheDBManager.PushLehrendehatLehrveranstaltung(id2, id3, id);
                MessageBox.Show("Eingabe war erfolgreich");
                ClearWindow();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Fehler bei der Eingabe");
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            ClearWindow();
            this.Hide();
        }

        private void ClearWindow()
        {
            txt_Lehrveranstaltungsnummer.Text = "";
            txt_Personalnummer.Text = "";
            txt_Fakultaetsnummer.Text = "";
        }
    }
}
