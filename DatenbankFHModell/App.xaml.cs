using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DatenbankFHModell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DBManager TheDBMAnger = new DBManager();
            Eventclass TheEvents = new Eventclass();
            //User 
            MainWindow Mynewwindow= new MainWindow(TheDBMAnger, TheEvents);
            Student TheSTudent = new Student(TheDBMAnger, TheEvents);
            Fakultät TheFakultät = new Fakultät(TheDBMAnger, TheEvents);
            Gebaeude TheGebaeude = new Gebaeude(TheDBMAnger, TheEvents);

            Presenter MyPresenter = new Presenter(TheEvents, TheDBMAnger, Mynewwindow, TheSTudent, TheFakultät, TheGebaeude);
            Mynewwindow.ShowDialog();
        }
    }
}
