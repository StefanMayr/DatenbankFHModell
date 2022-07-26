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
    /// Interaktionslogik für Lehrveranstaltung.xaml
    /// </summary>
    public partial class Lehrveranstaltungsclass : Window
    {
        DBManager TheDbManager;
        Eventclass TheEvents;
        DBManager TheDBManager;
        Eventclass TheEventClass;

        public Lehrveranstaltungsclass(DBManager thedbmanager, Eventclass theeventclass)
        {
            InitializeComponent();
            TheDbManager = thedbmanager;
            TheEvents = theeventclass;
        }

        private void btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            TheDbManager.PushLehrveranstaltung(Convert.ToInt32(txt_Lehrveranstaltungsnummer.Text), txt_Lehrveranstaltungsname.Text, Convert.ToDateTime(Dtp_Datetime.Text), Convert.ToInt32(txt_Einheit.Text));
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
