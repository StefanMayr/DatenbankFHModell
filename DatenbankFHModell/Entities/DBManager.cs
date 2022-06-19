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
        public void Update(string query)
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
            }
        }

        //Delete statement
        public void Delete(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
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
            string query = "INSERT INTO Student(Personalnummer,NameLehrender,WohnortLehrender,AlterLehrender,AusbildungLehrender, GeschlechtLehrender, Fakultät_Fakultätnummer) VALUES (" + Personalnummer + ",'" + Name + "','" + Wohnort + "'," + Alter + ",'" + Ausbildung + "','" + Geschlecht + "'," + Fakultätnummer + ");";
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
            string query = "INSERT INTO Lehrveranstaltung(Lehrverantaltungsnummer,NameLehrveranstaltung,DatumLehrveranstaltung,Einheit) VALUES (" + Lehrveranstaltungsnummer + ",'" + NameLehrveranstaltung + "'," + Einheit + ");";
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
        public void PushFakultaet(int Personalnummer, int Fakultaetnummer, int Lehrveranstaltungsnummer)
        {
            string query = "INSERT INTO Fakultät(Fakultätnummer,NameFakultät) VALUES (" + Fakultaetnummer + ",'" + NameFakultaet + "');";
            Insert(query);
        }

        /// <summary>
        /// Push into Lehrender has Lehrveranstaltung 
        /// </summary>
        /// <param name="Fakultaetnummer"></param>
        /// <param name="NameFakultaet"></param>
        public void PushLehrendehatLehrveranstaltung(int Fakultaetnummer, string NameFakultaet)
        {
            string query = "INSERT INTO Lehrende_has_Lehrveranstaltung(Personalnummer,Fakultätnummer,Lehrveranstaltungsnummer) VALUES (" + Personalnummer + "," + Fakultaetnummer + "," + Lehrveranstaltungsnummer + ");";
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
            string query = "INSERT INTO Lehrveranstaltung_has_raum(Lehrveranstaltungsnummer,Raumnummer,Gebaeudenummer) VALUES (" + Lehrveranstaltungsnummer + "," + Raumnummer + "," + Gebaeudenummer + ");";
            Insert(query);
        }

        /// <summary>
        /// Push Raum into DB
        /// </summary>
        /// <param name="Raumnummer"></param>
        /// <param name="Gebaeudenummer"></param>
        public void PushRaum(int Raumnummer, int Gebaeudenummer)
        {
            string query = "INSERT INTO raum(Raumnummer,Gebaeudenummer) VALUES (" + Raumnummer + "," + Gebaeudenummer + ");";
            Insert(query);
        }

        /// <summary>
        /// Push StudenthatLehrveranstaltung into DB
        /// </summary>
        /// <param name="Matrikelnummer"></param>
        /// <param name="Lehrveranstaltungsnummer"></param>
        public void PushStudenthatLehrverantaltung(int Matrikelnummer, int Lehrveranstaltungsnummer)
        {
            string query = "INSERT INTO Student_has_lehrveranstaltung(Matrikelnummer,Lehrveranstaltungsnummer) VALUES (" + Matrikelnummer + "," + Lehrveranstaltungsnummer + ");";
            Insert(query);
        }


    }
}
