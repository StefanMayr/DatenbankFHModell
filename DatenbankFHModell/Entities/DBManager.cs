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
using System.Diagnostics;
using System.IO;
//Add MySql Library
using MySql.Data.MySqlClient;


namespace DatenbankFHModell
{
    public class DBManager
    {
        private MySqlConnection connection;

        //Constructor
        public DBManager()
        {

        }

        //Insert statement
        public void Connect(string hostname, string port, string databasename, string username, string password)
        {
            string connectionString = "SERVER=" + hostname + ";" + "PORT=" + port + ";" + "DATABASE=" + databasename + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";" + "Connection Timeout =" + "300" + ";";
            connection = new MySqlConnection(connectionString);
            //open connection
            if (this.OpenConnection() == true)
            {
                //close connection     
                MessageBox.Show("Connection established to server: " + connection.DataSource + ", database: " + connection.Database);
                this.CloseConnection();
            }
            else
            {
                MessageBox.Show("Nicht funktioniert!");
            }
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(string query)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        private bool Update(string query)
        {
            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete statement
        /*
        public void Delete(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }*/

        private bool Delete(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();

                return true;
            }
            else
            {
                return false;
            }
        }

        //Select statement
        public List<string>[] Select(string query)
        {
            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["personID"] + "");
                    list[1].Add(dataReader["firstname"] + "");
                    list[2].Add(dataReader["secondname"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM person";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        /// <summary>
        /// Push Student into Db
        /// </summary>
        /// <param name="Matrikelnummer"></param>
        /// <param name="Name"></param>
        /// <param name="Wohnort"></param>
        /// <param name="Geschlecht"></param>
        /// <param name="Alter"></param>
        public void PushStudent(int Matrikelnummer, string Name, string Wohnort, string Geschlecht, int Alter)
        {
            string query = "INSERT INTO Student(Matrikelnummer,NameStudent,WohnortStudent,GeschlechtStudent,AlterStudent) VALUES (" + Matrikelnummer + ",'" + Name + "','" + Wohnort + "','" + Geschlecht + "'," + Alter + ");";
            Insert(query);
        }

        /// <summary>
        /// Push Lehrender into DB
        /// </summary>
        /// <param name="Personalnummer"></param>
        /// <param name="Name"></param>
        /// <param name="Wohnort"></param>
        /// <param name="Alter"></param>
        /// <param name="Ausbildung"></param>
        /// <param name="Geschlecht"></param>
        /// <param name="Fakultätnummer"></param>
        public void PushLehrender(int Personalnummer, string Name, string Wohnort, int Alter, string Ausbildung, string Geschlecht, int Fakultätnummer)
        {
            string query = "INSERT INTO lehrende(Personalnummer,NameLehrender,WohnortLehrender,AlterLehrender,AusbildungLehrender, GeschlechtLehrender, Fakultät_Fakultätnummer) VALUES (" + Personalnummer + ",'" + Name + "','" + Wohnort + "'," + Alter + ",'" + Ausbildung + "','" + Geschlecht + "'," + Fakultätnummer + ");";
            Insert(query);
        }

        /// <summary>
        /// Push Lehrverantalung into DB
        /// </summary>
        /// <param name="Lehrveranstaltungsnummer"></param>
        /// <param name="NameLehrveranstaltung"></param>
        /// <param name="Datum"></param>
        /// <param name="Einheit"></param>
        public void PushLehrveranstaltung(int Lehrveranstaltungsnummer,string NameLehrveranstaltung, DateTime Datum, int Einheit)
        {
            string query = "INSERT INTO Lehrveranstaltung(Lehrveranstaltungsnummer,NameLehrveranstaltung,DatumLehrveranstaltung,Einheit) VALUES (" + Lehrveranstaltungsnummer + ",'" + NameLehrveranstaltung + "','" + Datum.ToString("yyyy-MM-dd HH:mm:ss") + "' ," + Einheit + ");";
            Insert(query);
        }

        /// <summary>
        /// Push Gebaeude into DB
        /// </summary>
        /// <param name="Lehrveranstaltungsnummer"></param>
        /// <param name="NameLehrveranstaltung"></param>
        /// <param name="Datum"></param>
        /// <param name="Einheit"></param>
        public void PushGebaeude(int Gebauedenummer)
        {
            string query = "INSERT INTO Gebaeude(Gebaeudenummer) VALUES (" + Gebauedenummer + ");";
            Insert(query);
        }

        /// <summary>
        /// Push Fakultaet into DB
        /// </summary>
        /// <param name="Fakultaetnummer"></param>
        /// <param name="NameFakultaet"></param>
        public void PushFakultaet(int Fakultaetnummer, string NameFakultaet)
        {
            string query = "INSERT INTO Fakultät(Fakultätnummer,NameFakultät) VALUES (" + Fakultaetnummer + ",'" + NameFakultaet + "');";
            Insert(query);
        }

        /// <summary>
        /// Push into Lehrender has Lehrveranstaltung 
        /// </summary>
        /// <param name="Fakultaetnummer"></param>
        /// <param name="NameFakultaet"></param>
        public void PushLehrendehatLehrveranstaltung(int Personalnummer, int Fakultaetnummer, int Lehrveranstaltungsnummer)
        {
            string query = "INSERT INTO Lehrende_has_Lehrveranstaltung(Lehrende_Personalnummer,Lehrende_Fakultät_Fakultätnummer,Lehrveranstaltung_Lehrveranstaltungsnummer) VALUES (" + Personalnummer + "," + Fakultaetnummer + "," + Lehrveranstaltungsnummer + ");";
            Insert(query);
        }

        /// <summary>
        /// Push Lehrveranstaltung_has_Room into DB
        /// </summary>
        /// <param name="Lehrveranstaltungsnummer"></param>
        /// <param name="Raumnummer"></param>
        /// <param name="Gebaeudenummer"></param>
        public void PushLehrveranstaltunghatRaum(int Lehrveranstaltungsnummer, int Raumnummer, int Gebaeudenummer)
        {
            string query = "INSERT INTO Lehrveranstaltung_has_raum(Lehrveranstaltung_Lehrveranstaltungsnummer,Raum_Raumnummer,Raum_Gebaeude_Gebaeudenummer) VALUES (" + Lehrveranstaltungsnummer + "," + Raumnummer + "," + Gebaeudenummer + ");";
            Insert(query);
        }

        /// <summary>
        /// Push Raum into DB
        /// </summary>
        /// <param name="Raumnummer"></param>
        /// <param name="Gebaeudenummer"></param>
        public void PushRaum(int Raumnummer, int Gebaeudenummer)
        {
            string query = "INSERT INTO raum(Raumnummer,Gebaeude_Gebaeudenummer) VALUES (" + Raumnummer + "," + Gebaeudenummer + ");";
            Insert(query);
        }

        /// <summary>
        /// Push StudenthatLehrveranstaltung into DB
        /// </summary>
        /// <param name="Matrikelnummer"></param>
        /// <param name="Lehrveranstaltungsnummer"></param>
        public void PushStudenthatLehrverantaltung(int Matrikelnummer, int Lehrveranstaltungsnummer)
        {
            string query = "INSERT INTO Student_has_lehrveranstaltung(Student_Matrikelnummer,Lehrveranstaltung_Lehrveranstaltungsnummer) VALUES (" + Matrikelnummer + "," + Lehrveranstaltungsnummer + ");";
            Insert(query);
        }

        /// <summary>
        /// Pull Fakultaet Data from DB
        /// </summary>
        /// <returns></returns>
        public List<Fakultaetentity> PullFakultaet()
        {
            List<Fakultaetentity> list = new List<Fakultaetentity>();  
            
            if (this.OpenConnection() == true)
            {
                string query = "Select * from mydb.fakultät";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int FakultaetNr = 0;
                string NameFakultaet = "";

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        FakultaetNr = dataReader.GetInt16(0);
                    }
                    if (!dataReader.IsDBNull(1))
                    {
                        NameFakultaet = dataReader.GetString(1);
                    }
                    list.Add(new Fakultaetentity(FakultaetNr, NameFakultaet));
                }

            }
            //close Connection
            this.CloseConnection();

            return list;
        }

        /// <summary>
        /// Pull Gebaeude Data from DB
        /// </summary>
        /// <returns></returns>
        public List<Gebaeudeentity> PullGebaeude()
        {
            List<Gebaeudeentity> list = new List<Gebaeudeentity>();

            if (this.OpenConnection() == true)
            {
                string query = "Select * from mydb.gebaeude";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int GebaeudeNr = 0;

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        GebaeudeNr = dataReader.GetInt16(0);
                    }
                    list.Add(new Gebaeudeentity(GebaeudeNr));
                }

            }
            //close Connection
            this.CloseConnection();

            return list;
        }

        /// <summary>
        /// Pull Lehrende Data from DB
        /// </summary>
        /// <returns></returns>
        public List<Lehrendeentity> PullLehrende()
        {
            List<Lehrendeentity> list = new List<Lehrendeentity>();

            if (this.OpenConnection() == true)
            {
                string query = "Select * from mydb.lehrende";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int PersonalNr = 0;
                string Name = "";
                string Wohnort = "";
                int Alter = 0;
                string Ausbildung = "";
                string Geschlecht = "";
                int FakultaetNr = 0;

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        PersonalNr = dataReader.GetInt16(0);
                    }
                    if (!dataReader.IsDBNull(1))
                    {
                        Name = dataReader.GetString(1);
                    }
                    if (!dataReader.IsDBNull(2))
                    {
                        Wohnort = dataReader.GetString(2);
                    }
                    if (!dataReader.IsDBNull(3))
                    {
                        Alter = dataReader.GetInt16(3);
                    }
                    if (!dataReader.IsDBNull(4))
                    {
                        Ausbildung = dataReader.GetString(4);
                    }
                    if (!dataReader.IsDBNull(5))
                    {
                        Geschlecht = dataReader.GetString(5);
                    }
                    if (!dataReader.IsDBNull(6))
                    {
                        FakultaetNr = dataReader.GetInt16(6);
                    }
                    list.Add(new Lehrendeentity(PersonalNr, Name, Wohnort, Alter, Ausbildung, Geschlecht, FakultaetNr));
                }

            }
            //close Connection
            this.CloseConnection();

            return list;
        }

        /// <summary>
        /// Pull ZOT Lehrende_has_Lehrveranstaltungentity Data from DB
        /// </summary>
        /// <returns></returns>
        public List<Lehrende_has_Lehrveranstaltungentity> PullLehrende_has_Lehrveranstaltung()
        {
            List<Lehrende_has_Lehrveranstaltungentity> list = new List<Lehrende_has_Lehrveranstaltungentity>();

            if (this.OpenConnection() == true)
            {
                string query = "Select * from mydb.lehrende_has_lehrveranstaltung";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int Lehrende_PersonalNr = 0;
                int Lehrende_FakultaetNr = 0;
                int Lehrende_Lehrveranstaltungsnummer = 0;

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        Lehrende_PersonalNr = dataReader.GetInt16(0);
                    }
                    if (!dataReader.IsDBNull(1))
                    {
                        Lehrende_FakultaetNr = dataReader.GetInt16(1);
                    }
                    if (!dataReader.IsDBNull(2))
                    {
                        Lehrende_Lehrveranstaltungsnummer = dataReader.GetInt16(2);
                    }
                    list.Add(new Lehrende_has_Lehrveranstaltungentity(Lehrende_PersonalNr, Lehrende_FakultaetNr, Lehrende_Lehrveranstaltungsnummer));
                }

            }
            //close Connection
            this.CloseConnection();

            return list;
        }

        /// <summary>
        /// Pull Lehrveranstaltung from DB
        /// </summary>
        /// <returns></returns>
        public List<Lehrveranstaltungentity> PullLehrveranstaltung()
        {
            List<Lehrveranstaltungentity> list = new List<Lehrveranstaltungentity>();

            if (this.OpenConnection() == true)
            {
                string query = "Select * from mydb.lehrveranstaltung";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int LehrveranstaltungsNr = 0;
                string Lehrveranstaltungsnummer = "";
                DateTime Lehrveranstaltungdate = DateTime.Now;
                int Einheit = 0;

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        LehrveranstaltungsNr = dataReader.GetInt16(0);
                    }
                    if (!dataReader.IsDBNull(1))
                    {
                        Lehrveranstaltungsnummer = dataReader.GetString(1);
                    }
                    if (!dataReader.IsDBNull(2))
                    {
                        Lehrveranstaltungdate = dataReader.GetDateTime(2);
                    }
                    if (!dataReader.IsDBNull(3))
                    {
                        Einheit = dataReader.GetInt16(3);
                    }
                    list.Add(new Lehrveranstaltungentity(LehrveranstaltungsNr, Lehrveranstaltungsnummer, Lehrveranstaltungdate, Einheit));
                }

            }
            //close Connection
            this.CloseConnection();

            return list;
        }

        /// <summary>
        /// Pull ZOT Lehrveranstaltung_has_Raum Data from DB
        /// </summary>
        /// <returns></returns>
        public List<Lehrveranstaltung_has_raumentity> PullLehrveranstaltung_has_Raum()
        {
            List<Lehrveranstaltung_has_raumentity> list = new List<Lehrveranstaltung_has_raumentity>();

            if (this.OpenConnection() == true)
            {
                string query = "Select * from mydb.lehrveranstaltung_has_raum";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int LehrveranstaltungsNr = 0;
                int RaumNr = 0;
                int GebaeudeNr = 0;

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        LehrveranstaltungsNr = dataReader.GetInt16(0);
                    }
                    if (!dataReader.IsDBNull(1))
                    {
                        RaumNr = dataReader.GetInt16(1);
                    }
                    if (!dataReader.IsDBNull(2))
                    {
                        GebaeudeNr = dataReader.GetInt16(2);
                    }
                    list.Add(new Lehrveranstaltung_has_raumentity(LehrveranstaltungsNr, RaumNr, GebaeudeNr));
                }

            }
            //close Connection
            this.CloseConnection();

            return list;
        }

        /// <summary>
        /// Pull Raum Data from DB
        /// </summary>
        /// <returns></returns>
        public List<Raumentity> PullRaum()
        {
            List<Raumentity> list = new List<Raumentity>();

            if (this.OpenConnection() == true)
            {
                string query = "Select * from mydb.raum";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int RaumNr = 0;
                int GebaeudeNr = 0;

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        RaumNr = dataReader.GetInt16(0);
                    }
                    if (!dataReader.IsDBNull(1))
                    {
                        GebaeudeNr = dataReader.GetInt16(1);
                    }
                    list.Add(new Raumentity(RaumNr, GebaeudeNr));
                }

            }
            //close Connection
            this.CloseConnection();

            return list;
        }

        /// <summary>
        /// Pull student Data from DB
        /// </summary>
        /// <returns></returns>
        public List<Studententity> PullStudent()
        {
            List<Studententity> list = new List<Studententity>();

            if (this.OpenConnection() == true)
            {
                string query = "Select * from mydb.student";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int MatrikelNr = 0;
                string Name = "";
                string Wohnort = "";
                string Geschlecht = "";
                int Alter = 0;

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        MatrikelNr = dataReader.GetInt32(0);
                    }
                    if (!dataReader.IsDBNull(1))
                    {
                        Name = dataReader.GetString(1);
                    }
                    if (!dataReader.IsDBNull(2))
                    {
                        Wohnort = dataReader.GetString(2);
                    }
                    if (!dataReader.IsDBNull(3))
                    {
                        Geschlecht = dataReader.GetString(3);
                    }
                    if (!dataReader.IsDBNull(4))
                    {
                        Alter = dataReader.GetInt32(4);
                    }
                    list.Add(new Studententity(MatrikelNr, Name, Wohnort, Geschlecht, Alter));
                }

            }
            //close Connection
            this.CloseConnection();

            return list;
        }

        /// <summary>
        /// Pull Zot Student_has_Lehrveranstaltungentity from the DB
        /// </summary>
        /// <returns></returns>
        public List<Student_has_Lehrveranstaltungentity> PullStudent_has_Lehrveranstaltungentity()
        {
            List<Student_has_Lehrveranstaltungentity> list = new List<Student_has_Lehrveranstaltungentity>();

            if (this.OpenConnection() == true)
            {
                string query = "Select * from mydb.student_has_lehrveranstaltung";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int Student_Matrikelnummer = 0;
                int Lehrveranstaltung_Lehrveranstaltungsnummer = 0;

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        Student_Matrikelnummer = dataReader.GetInt16(0);
                    }
                    if (!dataReader.IsDBNull(1))
                    {
                        Lehrveranstaltung_Lehrveranstaltungsnummer = dataReader.GetInt16(1);
                    }
                    list.Add(new Student_has_Lehrveranstaltungentity(Student_Matrikelnummer, Lehrveranstaltung_Lehrveranstaltungsnummer));
                }

            }
            //close Connection
            this.CloseConnection();

            return list;
        }

        /// <summary>
        /// Delete a Fakultaet object from the Database
        /// </summary>
        /// <param name="Fakultaetnummer"></param>
        public void DeleteFakultaet(int Fakultaetnummer)
        {
            string query = "Delete from mydb.fakultät where Fakultätnummer =  '" + Fakultaetnummer + "';";
            if (this.Delete(query))
            {
                MessageBox.Show("Ausgewählte Fakultät wurde gelöscht.");
            }
            else
            {
                MessageBox.Show("Verbindung zur Datenbank abgebrochen.");
            }
        }

        /// <summary>
        /// Delete a Gebaeude object from the Database
        /// </summary>
        /// <param name="Gebaeudenummer"></param>
        public void DeleteGebaeude(int Gebaeudenummer)
        {
            string query = "Delete from mydb.gebaeude where Gebaeudenummer = '" + Gebaeudenummer + "';";
            if (this.Delete(query))
            {
                MessageBox.Show("Ausgewähltes Gebauede wurde aus der Datenbank entfernt.");
            }
            else
            {
                MessageBox.Show("Verbindung zur Datenbank abgebrochen.");
            }
        }

        /// <summary>
        /// Delete a Lehrende object from the Database
        /// </summary>
        /// <param name="Personalnummer"></param>
        public void DeleteLehrende(int Personalnummer)
        {
            string query = "Delete from mydb.lehrende where Personalnummer = '" + Personalnummer + "';";
            if (this.Delete(query))
            {
                MessageBox.Show("Ausgewählte Lehrperson wurde aus der Datenbank entfernt.");
            }
            else
            {
                MessageBox.Show("Verbindung zur Datenbank abgebrochen.");
            }
        }

        /// <summary>
        /// Delete a Lehrende_hasLehrveranstaltung object from the Database
        /// </summary>
        /// <param name="Personalnummer"></param>
        public void DeleteLehrende_has_lehrveranstaltung(int Lehrende_Personalnummer)
        {
            string query = "Delete from mydb.lehrende_has_lehrveranstaltung where Lehrende_Personalnummer = '" + Lehrende_Personalnummer + "';";
            if (this.Delete(query))
            {
                MessageBox.Show("Ausgewählte Verknüpfung der Lehrperson mit Lehrveranstaltung wurde aus der Datenbank entfernt.");
            }
            else
            {
                MessageBox.Show("Verbindung zur Datenbank abgebrochen.");
            }
        }

        /// <summary>
        /// Delete a Lehrveranstaltung object from the Database
        /// </summary>
        /// <param name="Personalnummer"></param>
        public void DeleteLehrveranstaltung(int Lehrveranstaltungsnummer)
        {
            string query = "Delete from mydb.lehrveranstaltung where Lehrveranstaltungsnummer = '" + Lehrveranstaltungsnummer + "';";
            if (this.Delete(query))
            {
                MessageBox.Show("Ausgewählte Lehrveranstaltung wurde aus der Datenbank entfernt.");
            }
            else
            {
                MessageBox.Show("Verbindung zur Datenbank abgebrochen.");
            }
        }

        /// <summary>
        /// Delete a Lehrveranstaltung_has_raum object from the Database
        /// </summary>
        /// <param name="Personalnummer"></param>
        public void DeleteLehrveranstaltung_has_raum(int Lehrveranstaltungsnummer)
        {
            string query = "Delete from mydb.lehrveranstaltung_has_raum where Lehrveranstaltung_Lehrveranstaltungsnummer = '" + Lehrveranstaltungsnummer + "';";
            if (this.Delete(query))
            {
                MessageBox.Show("Ausgewählte Verknüpfung der Lehrveranstaltung mit Raum wurde aus der Datenbank entfernt.");
            }
            else
            {
                MessageBox.Show("Verbindung zur Datenbank abgebrochen.");
            }
        }

        /// <summary>
        /// Delete a raum object from the Database
        /// </summary>
        /// <param name="Personalnummer"></param>
        public void DeleteRaum(int Raumnummer)
        {
            string query = "Delete from mydb.raum where Raumnummer = '" + Raumnummer + "';";
            if (this.Delete(query))
            {
                MessageBox.Show("Ausgewählter Raum wurde aus der Datenbank entfernt.");
            }
            else
            {
                MessageBox.Show("Verbindung zur Datenbank abgebrochen.");
            }
        }

        /// <summary>
        /// Delete a Student object from the Database
        /// </summary>
        /// <param name="Personalnummer"></param>
        public void DeleteStudent(int Matrikelnummer)
        {
            string query = "Delete from mydb.student where Matrikelnummer = '" + Matrikelnummer +"';";
            if (this.Delete(query))
            {
                MessageBox.Show("Ausgewählter Student wurde aus der Datenbank entfernt.");
            }
            else
            {
                MessageBox.Show("Verbindung zur Datenbank abgebrochen.");
            }
        }

        /// <summary>
        /// Delete a Studenthas_lehrveranstaltung object from the Database
        /// </summary>
        /// <param name="Personalnummer"></param>
        public void DeleteStudent_has_lehrveranstaltung(int Matrikelnummer)
        {
            string query = "Delete from mydb.student_has_lehrveranstaltung where Student_Matrikelnummer = '" + Matrikelnummer + "';";
            if (this.Delete(query))
            {
                MessageBox.Show("Ausgewählte Verknüpfung von Student mit Lehrveranstaltung wurde aus der Datenbank entfernt.");
            }
            else
            {
                MessageBox.Show("Verbindung zur Datenbank abgebrochen.");
            }
        }

        public void Update_Fakultaetname(int Fakultaetnummer, string Neuerfakultaetname)
        {
            string query = "Update mydb.fakultät set NameFakultät = '" + Neuerfakultaetname + "' where Fakultätnummer = '" + Fakultaetnummer + "';";

            if (this.Update(query))
            {
                MessageBox.Show("Aktualisierung erfolgreich.");
            }
            else
            {
                MessageBox.Show("Verbindung zur Datenbank abgebrochen.");
            }
        }

        public void Update_Lehrende(int Personalnummer, string Neuername, string NeuerWohn, int Neualter, string NeuAusbildung, string Neugeschl, int Neufakult)
        {
            string query = "Update mydb.lehrende set NameLehrender = '" + Neuername + "', WohnortLehrender = '" + NeuerWohn + "', AlterLehrender = " + Neualter + ", AusbildungLehrender = '" + NeuAusbildung + "', GeschlechtLehrender = '" + Neugeschl + "', Fakultät_Fakultätnummer = " + Neufakult + " where Personalnummer = " + Personalnummer + ";";

            if (this.Update(query))
            {
                MessageBox.Show("Aktualisierung erfolgreich.");
            }
            else
            {
                MessageBox.Show("Verbindung zur Datenbank abgebrochen.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Lehrveranstaltungsnummer"></param>
        /// <param name="Neuername"></param>
        /// <param name="NeuesDatum"></param>
        /// <param name="NeueEinheit"></param>
        public void Update_Lehrveranstaltung(int Lehrveranstaltungsnummer, string Neuername, DateTime NeuesDatum, int NeueEinheit)
        {
            string query = "Update mydb.lehrveranstaltung set NameLehrveranstaltung = '" + Neuername + "', DatumLehrveranstaltung = '" + NeuesDatum.ToString("yyyy-MM-dd HH:mm:ss") + "', Einheit = " + NeueEinheit + " where Lehrveranstaltungsnummer = " + Lehrveranstaltungsnummer + ";";

            if (this.Update(query))
            {
                MessageBox.Show("Aktualisierung erfolgreich.");
            }
            else
            {
                MessageBox.Show("Verbindung zur Datenbank abgebrochen.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Matrikelnummer"></param>
        /// <param name="Neuername"></param>
        /// <param name="NeuerWohnort"></param>
        /// <param name="NeuesGeschlecht"></param>
        /// <param name="NeueAlter"></param>
        public void Update_Student(int Matrikelnummer, string Neuername, string NeuerWohnort, string NeuesGeschlecht, int NeueAlter)
        {
            string query = "Update mydb.student set NameStudent = '" + Neuername + "', WohnortStudent = '" + NeuerWohnort + "', GeschlechtStudent = '" + NeuesGeschlecht + "', AlterStudent = " + NeueAlter + " where Matrikelnummer = " + Matrikelnummer +";";

            if (this.Update(query))
            {
                MessageBox.Show("Aktualisierung erfolgreich.");
            }
            else
            {
                MessageBox.Show("Verbindung zur Datenbank abgebrochen.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Raumnummer"></param>
        /// <param name="Neuername"></param>
        /// <param name="NeuerWohnort"></param>
        /// <param name="NeuesGeschlecht"></param>
        /// <param name="NeueAlter"></param>
        public void Update_Raum(int Raumnummer, int NeueGebäudenummer)
        {
            string query = "Update mydb.raum set Gebaeude_Gebaeudenummer = '" + NeueGebäudenummer + "' where Raumnummer = '" + Raumnummer + "';";


            try
            {             
                if (this.Update(query))
                {
                    MessageBox.Show("Aktualisierung erfolgreich.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Es können nur Gebäudenummern von bestehenden Gebäuden gewählt werden!");
            }
        }

        public List<Student_has_Lehrveranstaltungentity> PullStudent_has_Lehrveranstaltung()
        {
            List<Student_has_Lehrveranstaltungentity> studenthassome = new List<Student_has_Lehrveranstaltungentity>();

            if (this.OpenConnection() == true)
            {
                string query = "Select student_has_lehrveranstaltung.Student_Matrikelnummer, student.NameStudent, student_has_lehrveranstaltung.Lehrveranstaltung_Lehrveranstaltungsnummer, mydb.lehrveranstaltung.NameLehrveranstaltung, mydb.lehrveranstaltung.DatumLehrveranstaltung, mydb.lehrveranstaltung.Einheit from (mydb.student inner join mydb.student_has_lehrveranstaltung on student_has_lehrveranstaltung.Student_Matrikelnummer = student.Matrikelnummer) inner join mydb.lehrveranstaltung on mydb.lehrveranstaltung.Lehrveranstaltungsnummer = mydb.student_has_lehrveranstaltung.Lehrveranstaltung_Lehrveranstaltungsnummer";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int Matrikelnummer = 0;
                string NameStudent = "";
                int Lehrveranstaltung_Lehrveranstaltungsnummer = 0;
                string NameLehrv = "";
                DateTime Date = DateTime.Now;
                int Einheit = 0;

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        Matrikelnummer = dataReader.GetInt16(0);
                    }
                    if (!dataReader.IsDBNull(1))
                    {
                        NameStudent = dataReader.GetString(1);
                    }
                    if (!dataReader.IsDBNull(2))
                    {
                        Lehrveranstaltung_Lehrveranstaltungsnummer = dataReader.GetInt16(2);
                    }
                    if (!dataReader.IsDBNull(3))
                    {
                        NameLehrv = dataReader.GetString(3);
                    }
                    if (!dataReader.IsDBNull(4))
                    {
                        Date = dataReader.GetDateTime(4);
                    }
                    if (!dataReader.IsDBNull(5))
                    {
                        Einheit = dataReader.GetInt16(5);
                    }
                    studenthassome.Add(new Student_has_Lehrveranstaltungentity(NameStudent , Matrikelnummer, Lehrveranstaltung_Lehrveranstaltungsnummer, NameLehrv, Date, Einheit));
                }

            }
            //close Connection
            this.CloseConnection();

            return studenthassome;
        }

        public List<Lehrende_has_Lehrveranstaltungentity> PullLehrende_has_Lehrveranstaltungentity()
        {
            List<Lehrende_has_Lehrveranstaltungentity> Lehrendelist = new List<Lehrende_has_Lehrveranstaltungentity>();

            if (this.OpenConnection() == true)
            {
                string query = "Select lehrende_has_lehrveranstaltung.Lehrende_Personalnummer, mydb.lehrende.NameLehrender, lehrende_has_lehrveranstaltung.Lehrveranstaltung_Lehrveranstaltungsnummer, mydb.lehrveranstaltung.NameLehrveranstaltung, mydb.lehrveranstaltung.DatumLehrveranstaltung, mydb.lehrveranstaltung.Einheit from (mydb.lehrende inner join mydb.lehrende_has_lehrveranstaltung on lehrende_has_lehrveranstaltung.Lehrende_Personalnummer = lehrende.Personalnummer) inner join mydb.lehrveranstaltung on mydb.lehrveranstaltung.Lehrveranstaltungsnummer = mydb.lehrende_has_lehrveranstaltung.Lehrveranstaltung_Lehrveranstaltungsnummer";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int Personalnummer = 0;
                string NameLehrender = "";
                int Lehrveranstaltung_Lehrveranstaltungsnummer = 0;
                string NameLehrv = "";
                DateTime Date = DateTime.Now;
                int Einheit = 0;

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        Personalnummer = dataReader.GetInt16(0);
                    }
                    if (!dataReader.IsDBNull(1))
                    {
                        NameLehrender = dataReader.GetString(1);
                    }
                    if (!dataReader.IsDBNull(2))
                    {
                        Lehrveranstaltung_Lehrveranstaltungsnummer = dataReader.GetInt16(2);
                    }
                    if (!dataReader.IsDBNull(3))
                    {
                        NameLehrv = dataReader.GetString(3);
                    }
                    if (!dataReader.IsDBNull(4))
                    {
                        Date = dataReader.GetDateTime(4);
                    }
                    if (!dataReader.IsDBNull(5))
                    {
                        Einheit = dataReader.GetInt16(5);
                    }
                    Lehrendelist.Add(new Lehrende_has_Lehrveranstaltungentity(NameLehrender, Personalnummer, Lehrveranstaltung_Lehrveranstaltungsnummer, NameLehrv, Date, Einheit));
                }

            }
            //close Connection
            this.CloseConnection();

            return Lehrendelist;
        }

        public List<Lehrveranstaltung_has_raumentity> PullLehrveranstaltung_has_raumentity()
        {
            List<Lehrveranstaltung_has_raumentity> Lerhveranstaltungslist = new List<Lehrveranstaltung_has_raumentity>();

            if (this.OpenConnection() == true)
            {
                string query = "Select mydb.lehrveranstaltung_has_raum.Lehrveranstaltung_Lehrveranstaltungsnummer, mydb.lehrveranstaltung.NameLehrveranstaltung, mydb.lehrveranstaltung.DatumLehrveranstaltung, mydb.lehrveranstaltung.Einheit ,mydb.lehrveranstaltung_has_raum.Raum_Raumnummer, mydb.lehrveranstaltung_has_raum.Raum_Gebaeude_Gebaeudenummer from mydb.lehrveranstaltung_has_raum inner join mydb.lehrveranstaltung on mydb.lehrveranstaltung_has_raum.Lehrveranstaltung_Lehrveranstaltungsnummer = mydb.lehrveranstaltung.Lehrveranstaltungsnummer";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int Lehrveranstaltung_Lehrveranstaltungsnummer = 0;
                string NameLehrv = "";
                DateTime Date = DateTime.Now;
                int Einheit = 0;
                int Raumnummer = 0;
                int Gebaeudenummer = 0;

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        Lehrveranstaltung_Lehrveranstaltungsnummer = dataReader.GetInt32(0);
                    }
                    if (!dataReader.IsDBNull(1))
                    {
                        NameLehrv = dataReader.GetString(1);
                    }
                    if (!dataReader.IsDBNull(2))
                    {
                        Date = dataReader.GetDateTime(2);
                    }
                    if (!dataReader.IsDBNull(3))
                    {
                        Einheit = dataReader.GetInt16(3);
                    }
                    if (!dataReader.IsDBNull(4))
                    {
                        Raumnummer = dataReader.GetInt16(4);
                    }
                    if (!dataReader.IsDBNull(5))
                    {
                        Gebaeudenummer = dataReader.GetInt16(5);
                    }
                    Lerhveranstaltungslist.Add(new Lehrveranstaltung_has_raumentity(NameLehrv, Lehrveranstaltung_Lehrveranstaltungsnummer, Date, Einheit, Raumnummer, Gebaeudenummer));
                }

            }
            //close Connection
            this.CloseConnection();

            return Lerhveranstaltungslist;
        }

    }
}
