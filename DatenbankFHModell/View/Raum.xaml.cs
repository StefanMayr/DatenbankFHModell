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
    /// Interaktionslogik für Raum.xaml
    /// </summary>
    public partial class Raum : Window
    {
        DBManager TheDBManager;
        Eventclass TheEvents;
        public Raum(DBManager thedbmanager, Eventclass theEvents)
        {
            InitializeComponent();
            TheDBManager = thedbmanager;
            TheEvents = theEvents;
            TheEvents.InsertNewRaumEntity_requ += Insert_RaumData;
        }

        private void btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            if (TheDBManager != null && txt_Raumnummer.Text != "" && txt_Gebäudenummer.Text != "" && int.TryParse(txt_Raumnummer.Text, out int result) && int.TryParse(txt_Gebäudenummer.Text, out int result2))
            {
                TheDBManager.PushRaum(Convert.ToInt32(txt_Raumnummer.Text), Convert.ToInt32(txt_Gebäudenummer.Text));
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
            ClearWindow();
            this.Hide();
        }

        private void ClearWindow()
        {
            txt_Gebäudenummer.Text = "";
            txt_Raumnummer.Text = "";
        }

        private void btn_Drop_Click(object sender, RoutedEventArgs e)
        {
            TheDBManager.DeleteRaum(Convert.ToInt16(txt_Raumnummer.Text));
            ClearWindow();

        }
        private void Insert_RaumData(object sender,Raumentity e)
        {
            txt_Raumnummer.Text = Convert.ToString(e.Raumnummer);
            txt_Gebäudenummer.Text = Convert.ToString(e.Gebaeudenummer);
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
