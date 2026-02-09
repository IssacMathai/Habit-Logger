using System;
using Microsoft.Data.Sqlite;

namespace HabitTracker
{   
    class Program
    {
        const string CONNECTION_STRING = @"Data Source=habit-tracker.db";
        
        static void Main(string[] args)
        {
            using (var connection = new SqliteConnection(CONNECTION_STRING)) {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = 
                    @"CREATE TABLE IF NOT EXISTS drinking_water (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT NOT NULL,
                    Quantity INTEGER
                    )";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }

            GetUserInput();
        }

        static void GetUserInput()
        {
            Console.Clear();
            bool closeApp = false;
            while (!closeApp)
            {
                Console.WriteLine("MAIN MENU:");
                Console.WriteLine("Type 0 to exit.");
                Console.WriteLine("Type 1 to View All Records.");
                Console.WriteLine("Type 2 to Insert Record.");
                Console.WriteLine("Type 3 to Delete Record.");
                Console.WriteLine("Type 4 to Update Record.");
                Console.WriteLine("------------------------------\n");
                string? userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        closeApp = true;
                        break;
                    case "1":
                        ViewAllRecords();
                        break;
                    case "2":
                        InsertRecord();
                        break;
                    case "3":
                        DeleteRecord();
                        break;
                    case "4":
                        UpdateRecord();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
        }       
    }
        private static void InsertRecord()
        {
            Console.WriteLine("------------------------------\n");
            Console.WriteLine("Please type the date of the record you want to insert (format: YYYY-MM-DD):");            
            string? dateInput = Console.ReadLine();
            Console.WriteLine("Please type the number of water glasses you drank on that day:");
            string? quantityInput = Console.ReadLine();

            using (var connection = new SqliteConnection(CONNECTION_STRING)) {
            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText = 
                @"INSERT INTO drinking_water (Date, Quantity) VALUES ($date, $quantity)";
            tableCmd.Parameters.AddWithValue("$date", dateInput);
            tableCmd.Parameters.AddWithValue("$quantity", quantityInput);

            tableCmd.ExecuteNonQuery();

            connection.Close();
            }
        }

        private static void UpdateRecord()
        {
            throw new NotImplementedException();
        }

        private static void DeleteRecord()
        {
            throw new NotImplementedException();
        }


        private static void ViewAllRecords()
        {
            throw new NotImplementedException();
        }
    }
}