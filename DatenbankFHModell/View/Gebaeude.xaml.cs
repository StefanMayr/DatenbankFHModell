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
    /// Interaktionslogik für Gebaeude.xaml
    /// </summary>
    public partial class Gebaeude : Window
    {
        DBManager TheDBManager;
        Eventclass TheEvents;

        public Gebaeude(DBManager thedbmanager, Eventclass theEvents)
        {
            InitializeComponent();
            TheDBManager = thedbmanager;
            TheEvents = theEvents;
        }

        private void btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(txt_Gebaude.Text, out int id))
            {
                TheDBManager.PushGebaeude(Convert.ToInt32(txt_Gebaude.Text));
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
            ClearWindow();
        }

        private void ClearWindow()
        {
            txt_Gebaude.Text = "";
        }
    }
}
