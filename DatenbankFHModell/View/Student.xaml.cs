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
    /// Interaktionslogik für Student.xaml
    /// </summary>
    public partial class Student : Window
    {
        DBManager TheDBManager;
        Eventclass TheEvents;
        public Student(DBManager thedbmanager, Eventclass theEvents)
        {
            InitializeComponent();
            TheDBManager = thedbmanager;
            TheEvents = theEvents;
        }

        private void btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txt_Matr.Text, out int id) && int.TryParse(txt_Alter.Text, out int id2))
            {
                TheDBManager.PushStudent(Convert.ToInt32(txt_Matr.Text), txt_Name.Text, txt_Wohnort.Text, txt_Geschl.Text, Convert.ToInt32(txt_Alter.Text));
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
            txt_Matr.Text = "";
            txt_Name.Text = "";
            txt_Wohnort.Text = "";
            txt_Geschl.Text = "";
            txt_Alter.Text = "";
        }
    }
}
