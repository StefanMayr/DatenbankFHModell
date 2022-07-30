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
            TheEvents.InsertNewStudentEntity_requ += Insert_StudentData;
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

        private void btn_Drop_Click(object sender, RoutedEventArgs e)
        {
            TheDBManager.DeleteStudent(Convert.ToInt32(txt_Matr.Text));
            ClearWindow();

        }

        private void Insert_StudentData(object sender, Studententity e)
        {
            txt_Matr.Text = Convert.ToString(e.Matrikelnummer);
            txt_Name.Text = Convert.ToString(e.Studentname);
            txt_Wohnort.Text = Convert.ToString(e.StudentWohnort);
            txt_Geschl.Text = Convert.ToString(e.StudentGeschlecht);
            txt_Alter.Text = Convert.ToString(e.StudentAlter);
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            TheDBManager.Update_Student(Convert.ToInt16(txt_Matr.Text), txt_Name.Text, txt_Wohnort.Text, txt_Geschl.Text, Convert.ToInt16(txt_Alter.Text));
        }
    }
}
