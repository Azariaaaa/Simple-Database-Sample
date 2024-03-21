using MySqlConnector;
using System.Data.SqlClient;
using System.Text;

namespace BDD_C__Exo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateDB();
            SeedDB();
            GetAllEmployee();
        }
        public static void CreateDB() 
        {
            Console.WriteLine("Creating DB..");
            string sql = "DROP DATABASE IF EXISTS ExoCBDatabase; CREATE DATABASE ExoCBDatabase";
            using (MySqlCommand command = new MySqlCommand(sql, Connection.GetInstance()))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Database created.");
            }
        }
        public static void SeedDB()
        {
            //---------------- Creating Tables
            string sql = @"USE ExoCBDatabase;";
            sql += "CREATE TABLE Entreprise(Id INT AUTO_INCREMENT PRIMARY KEY,Nom VARCHAR(50),Location INT);";
            sql += "CREATE TABLE Pays(Id INT AUTO_INCREMENT PRIMARY KEY,Nom VARCHAR(50));";
            sql += "CREATE TABLE Employee(Id INT AUTO_INCREMENT PRIMARY KEY,Nom VARCHAR(50),Prenom VARCHAR(50), DateNaissance DATE);";
            sql += "CREATE TABLE Appartenir(IdEntreprise INT, IdEmployee INT);";


            //---------------- Feeding Table Pays
            sql += "INSERT INTO Pays (Nom) VALUES ('France');";
            sql += "INSERT INTO Pays (Nom) VALUES ('USA');";
            sql += "INSERT INTO Pays (Nom) VALUES ('Allemagne');";


            //---------------- Feeding Table Entreprise
            sql += "INSERT INTO Entreprise (Nom, Location) VALUES ('Shell', 2);";
            sql += "INSERT INTO Entreprise (Nom, Location) VALUES ('Total', 1);";
            sql += "INSERT INTO Entreprise (Nom, Location) VALUES ('Monsanto', 3);";
            sql += "INSERT INTO Entreprise (Nom, Location) VALUES ('LaFarge', 1);";


            //---------------- Feeding Table Employee
            sql += "INSERT INTO Employee (Nom, Prenom, DateNaissance) VALUES ('Kuster', 'Louis', '1992-10-26');";
            sql += "INSERT INTO Employee (Nom, Prenom, DateNaissance) VALUES ('Han', 'Necati', '1989-06-11');";
            sql += "INSERT INTO Employee (Nom, Prenom, DateNaissance) VALUES ('Cerf', 'Alexandre', '1998-01-05');";
            sql += "INSERT INTO Employee (Nom, Prenom, DateNaissance) VALUES ('Cheraj', 'Imane', '2000-08-20');";


            //---------------- Feeding Table Appartenir
            sql += "INSERT INTO Appartenir (IdEntreprise, IdEmployee) VALUES (1,1);";
            sql += "INSERT INTO Appartenir (IdEntreprise, IdEmployee) VALUES (2,2);";
            sql += "INSERT INTO Appartenir (IdEntreprise, IdEmployee) VALUES (3,3);";
            sql += "INSERT INTO Appartenir (IdEntreprise, IdEmployee) VALUES (4,4);";



            using (MySqlCommand command = new MySqlCommand(sql, Connection.GetInstance()))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Seed DB Done.");
            }

        }
        public static void GetAllEmployee()
        {
            Console.WriteLine("Reading employees data..");
            string sql = "SELECT * FROM Employee;";

            using (MySqlCommand command = new MySqlCommand(sql, Connection.GetInstance()))
            {
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} {2} {3}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3));
                }

                Console.WriteLine("Read and Display done.");
            }
        }
    }
}
