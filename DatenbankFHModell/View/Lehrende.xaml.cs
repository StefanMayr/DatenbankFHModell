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
           TheDBManager.PushLehrender(Convert.ToInt32(txt_Pers.Text), txt_Name.Text, txt_Wohnort.Text,Convert.ToInt32(txt_Alter.Text), txt_Ausbildung.Text, txt_Geschl.Text, Convert.ToInt32(txt_Fakultät.Text));
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
