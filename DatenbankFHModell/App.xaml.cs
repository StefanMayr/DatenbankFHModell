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
            DBManager TheDBManager = new DBManager();
            Eventclass TheEvents = new Eventclass();
            //User 
            MainWindow Mynewwindow= new MainWindow(TheDBManager, TheEvents);
            Student TheSTudent = new Student(TheDBManager, TheEvents);
            Fakultät TheFakultät = new Fakultät(TheDBManager, TheEvents);
            Gebaeude TheGebaeude = new Gebaeude(TheDBManager, TheEvents);
            Lehrendeclass TheLehrendenclass = new Lehrendeclass(TheDBManager, TheEvents);
            Lehrveranstaltungsclass TheLehrveranstaltungsclass = new Lehrveranstaltungsclass(TheDBManager, TheEvents);
            Raum TheRaumpage = new Raum(TheDBManager, TheEvents);

            Presenter MyPresenter = new Presenter(TheEvents, TheDBManager, Mynewwindow, TheSTudent, TheFakultät, TheGebaeude, TheLehrendenclass, TheLehrveranstaltungsclass, TheRaumpage);
            Mynewwindow.ShowDialog();
        }
    }
}
