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
    /// Interaktionslogik für Lehrveranstaltung_has_Raum.xaml
    /// </summary>
    public partial class Lehrveranstaltung_has_Raum : Window
    {
        DBManager TheDBManager;
        public Lehrveranstaltung_has_Raum(DBManager thedbmanager)
        {
            InitializeComponent();
            TheDBManager = thedbmanager;
        }

        private void btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txt_Lehrveranstaltungsnummer.Text, out int id) && int.TryParse(txt_Raumnummer.Text, out int id2) && int.TryParse(txt_Lehrveranstaltungsnummer.Text, out int id3))
            {
                TheDBManager.PushLehrveranstaltunghatRaum(id, id2, id3);
            }
            else
            {
                MessageBox.Show("Fehler bei der Eingabe");
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
