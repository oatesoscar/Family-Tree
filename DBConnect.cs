using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Family_Tree
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "10.0.0.50";
            database = "familytree";
            uid = "FamilyTree";
            password = "BJFljZMkwS3WCNtx";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
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
                // Error types
                // 0: Cannot connect to server.
                // 1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
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
            catch (Exception)
            {
                Console.WriteLine("Cannot close the connection");
                return false;
            }
        }

        //Insert statement
        public void Insert(Person person)
        {
            string query = $"INSERT INTO `person`(`First Name`, `Middle Name`, `Last Name`, `Date Of Birth`, `Birth City`, `Birth Country`, `Family Name`, `Father First Name`, `Father Last Name`, `Mother First Name`, `Mother Last Name`, `Is Alive`, `Has Family`, `Is A Family Member`, `Has Parents`, `Has Siblings`, `Has Children`) " +
                           $"VALUES('{person.FirstName}','{person.MiddleName}','{person.LastName}','{person.DateOfBirth}','{person.BirthCity}','{person.BirthCountry}','{person.FamilyName}','{person.FatherFirstName}','{person.FatherLastName}','{person.MotherFirstName}','{person.MotherLastName}','{person.convertToInt(person.IsAlive)}','{person.convertToInt(person.HasFamily)}','{person.convertToInt(person.IsAFamilyMember)}','{person.convertToInt(person.HasParents)}','{person.convertToInt(person.HasSiblings)}','{person.convertToInt(person.HasChildren)}')";
            
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
        public void Update(Person person)
        {
            string query = $"UPDATE `person` SET `First Name`={person.FirstName},`Middle Name`={person.MiddleName},`Last Name`={person.LastName},`Date Of Birth`={person.DateOfBirth},`Birth City`={person.BirthCity},`Birth Country`={person.BirthCountry},`Family Name`={person.FamilyName},`Father First Name`={person.FatherFirstName},`Father Last Name`={person.FatherLastName},`Mother First Name`={person.MotherFirstName},`Mother Last Name`={person.MotherLastName},`Is Alive`={person.IsAlive},`Has Family`={person.HasFamily},`Is A Family Member`={person.IsAFamilyMember},`Has Parents`={person.HasParents},`Has Siblings`={person.HasSiblings},`Has Children`={person.HasChildren},`DateModified`={DateTime.Now}, WHERE ID = {person.ID} ";

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
        public void Delete(Person person)
        {
            string query = $"DELETE FROM `person` WHERE ID = {person.ID} AND `Last Name`= {person.LastName}";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void ListPeople()
        {

        }

        /*
        public List<string>[] Select()
        {
            string query = "SELECT * FROM `person`";

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
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
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

        */

        /*
        //Count statement
        public int Count()
        {
        }
        */

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
        
    }
}
