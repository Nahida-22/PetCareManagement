using System;
using System.Collections.Generic;

namespace PawfectCareLtd.Data.DataRetrieval
{
    public class Database
    {
        private readonly Dictionary<string, Table> tables = new();

        public void AddTable(Table table) => tables[table.Name] = table;

        public Table GetTable(string name) => tables[name];

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
}