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

            Student_has_Lehrveranstaltung TheStudent_h_LPage = new Student_has_Lehrveranstaltung(TheDBManager);
            Lehrender_has_Lehrveranstaltung TheLehrende_h_LPage = new Lehrender_has_Lehrveranstaltung(TheDBManager);
            Lehrveranstaltung_has_Raum TheLehrver_h_RPage = new Lehrveranstaltung_has_Raum(TheDBManager);

            Presenter MyPresenter = new Presenter(TheEvents, TheDBManager, Mynewwindow, TheSTudent, TheFakultät, TheGebaeude, TheLehrendenclass, TheLehrveranstaltungsclass, TheRaumpage, TheStudent_h_LPage, TheLehrende_h_LPage, TheLehrver_h_RPage);
            Mynewwindow.ShowDialog();
        }
    }
}
