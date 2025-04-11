// Import dependencies.
using System;
using System.Collections.Generic;

namespace PawfectCareLtd.Data.DataRetrieval // Define the namespace for the application.
{

    // Class the create the in memory database.
    public class Database
    {
        // Dictionary that store table using the table names as key.
        private readonly Dictionary<string, Table> tables = new();

        // Method that add a table to the database.
        public void AddTable(Table table) => tables[table.Name] = table;

        // Method that retrieves a table with their name (using the key).
        public Table GetTable(string name) => tables[name];

        // Utility function to display foreign key references between two tables.
        public void PrintForeignReference(string fromTableName, string toTableName, string foreignKeyField)
        {
            var fromTable = GetTable(fromTableName);
            var toTable = GetTable(toTableName);

            Console.WriteLine($"\n{fromTableName} referencing {toTableName}:");
            foreach (var record in fromTable.GetAll())
            {
                string fk = record[foreignKeyField].ToString();
                var referenced = toTable.Get(fk);
                Console.WriteLine($"{fromTableName} Record: {record["Name"]}, linked to {toTableName} Record: {referenced["Name"]}");
            }
        }
    }


    // Static class that acts as a global reference to the in memory database
    public static class InMemoryDatabase
    {
        // Define the the global instance of the in memory database.
        public static Database InMemoryDatabaseInstance;
    }
}