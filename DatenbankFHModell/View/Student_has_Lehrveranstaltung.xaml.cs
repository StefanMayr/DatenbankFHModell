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
    /// Interaktionslogik für Student_has_Lehrveranstaltung.xaml
    /// </summary>
    public partial class Student_has_Lehrveranstaltung : Window
    {
        DBManager TheDbManager;
        public Student_has_Lehrveranstaltung(DBManager thedbmanager)
        {
            InitializeComponent();
            TheDbManager = thedbmanager;
        }

        private void btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(txt_Lehrveranstaltungsnummer.Text, out int id) && int.TryParse(txt_Matrikelnnummer.Text, out int id2))
            {
                TheDbManager.PushStudenthatLehrverantaltung(id2, id);
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
