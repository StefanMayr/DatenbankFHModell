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
    /// Interaktionslogik für Lehrende.xaml
    /// </summary>
    public partial class Lehrendeclass : Window
    {
        DBManager TheDBManager;
        Eventclass TheEventClass;
        public Lehrendeclass(DBManager thedbmanager, Eventclass theeventclass)
        {
            InitializeComponent();
            TheDBManager = thedbmanager;
            TheEventClass = theeventclass;
        }

        private void btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txt_Pers.Text, out int id) && int.TryParse(txt_Alter.Text, out int id2) && int.TryParse(txt_Fakultät.Text, out int id3))
            {
                TheDBManager.PushLehrender(Convert.ToInt32(txt_Pers.Text), txt_Name.Text, txt_Wohnort.Text, Convert.ToInt32(txt_Alter.Text), txt_Ausbildung.Text, txt_Geschl.Text, Convert.ToInt32(txt_Fakultät.Text));
                MessageBox.Show("Eingabe war erfolgreich");
                ClearWindow();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Falsche Eingabe!");
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ClearWindow()
        {
            txt_Pers.Text = "";
            txt_Name.Text = "";
            txt_Wohnort.Text = "";
            txt_Geschl.Text = "";
            txt_Fakultät.Text = "";
            txt_Ausbildung.Text = "";
            txt_Alter.Text = "";
        }
    }
}
