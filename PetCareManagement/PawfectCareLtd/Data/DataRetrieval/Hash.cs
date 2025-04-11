using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Models;


namespace PawfectCareLtd.Data.DataRetrieval.cs

{

    public class Record
    {
        // Dictionary to store fields of the record with key-value pairs
        public Dictionary<string, object> Fields = new Dictionary<string, object>();

        public object this[string field]
        {
            get => Fields[field];
            set => Fields[field] = value;
        }
        // Override ToString to display fields of the record in a readable format
        public override string ToString()
        {
            var entries = string.Join(", ", Fields);
            return $"{{ {entries} }}";
        }
    }

    // Custom simple hashtable using separate chaining
    public class HashTable<K, V>
    {
        private const int Size = 101; // Size of the hash table
        private LinkedList<KeyValuePair<K, V>>[] buckets = new LinkedList<KeyValuePair<K, V>>[Size];

        // Method to calculate the index of the bucket for a given key
        private int GetIndex(K key)
        {
            return Math.Abs(key.GetHashCode()) % Size;
        }
        // Add a key-value pair to the hashtable
        public void Add(K key, V value)
        {
            int index = GetIndex(key);
            if (buckets[index] == null)
                buckets[index] = new LinkedList<KeyValuePair<K, V>>();
            // Check if the key already exists, throw exception if it does
            foreach (var pair in buckets[index])
            {
                if (EqualityComparer<K>.Default.Equals(pair.Key, key))
                    throw new Exception("Duplicate key");
            }
            // Add the new key-value pair to the bucket
            buckets[index].AddLast(new KeyValuePair<K, V>(key, value));
        }
        // Remove a key-value pair by key
        public bool Remove(K key)
        {
            int index = GetIndex(key);
            if (buckets[index] != null)
            {
                var node = buckets[index].First;
                while (node != null)
                {
                    if (EqualityComparer<K>.Default.Equals(node.Value.Key, key))
                    {
                        buckets[index].Remove(node);// Remove the node
                        return true;
                    }
                    node = node.Next;
                }
            }
            return false;
        }

        // Get the value for a given key
        public V Get(K key)
        {
            int index = GetIndex(key);
            if (buckets[index] != null)
            {
                foreach (var pair in buckets[index])
                {
                    if (EqualityComparer<K>.Default.Equals(pair.Key, key))
                        return pair.Value;
                }
            }
            throw new KeyNotFoundException();
        }
        // Check if the key exists in the hashtable
        public bool ContainsKey(K key)
        {
            int index = GetIndex(key);
            if (buckets[index] != null)
            {
                foreach (var pair in buckets[index])
                {
                    if (EqualityComparer<K>.Default.Equals(pair.Key, key))
                        return true;
                }
            }
            return false;
        }

        public IEnumerable<KeyValuePair<K, V>> GetAll()
        {
            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    foreach (var pair in bucket)
                        yield return pair;
                }
            }
        }
    }
    // Represents a table in the database, with operations for inserting, updating, and deleting records
    public class Table
    {
        private HashTable<string, Record> rows = new HashTable<string, Record>();  // Hashtable to store rows by primary key
        public string Name { get; }
        private string primaryKey;

        private readonly DatabaseContext _dbContext;// Database context for interacting with SQL database

        public Table(string name, string primaryKeyField, DatabaseContext dbContext)
        {
            Name = name;
            primaryKey = primaryKeyField;
            _dbContext = dbContext;
        }

        // Insert a new record into the table
        public void Insert(Record record, bool skipDb = false)
        {
            string key = record[primaryKey].ToString();
            rows.Add(key, record);
            // If the table is "Location", also save the record to the database
            if (Name == "Location" && !skipDb)


            {
                var entity = new Location
                {
                    LocationID = record["LocationID"].ToString(),
                    Name = record["Name"].ToString(),
                    Address = record["Address"].ToString(),
                    Phone = record["Phone"].ToString(),
                    Email = record["Email"].ToString()
                };

                _dbContext.Locations.Add(entity);
                _dbContext.SaveChanges();
            }
        }




        // Retrieve a record by its primary key value

        public Record Get(string primaryKeyValue)
        {
            return rows.Get(primaryKeyValue);
        }
        public void Delete(string primaryKeyValue)
        {
            if (!rows.Remove(primaryKeyValue))
                throw new KeyNotFoundException($"No record found with key: {primaryKeyValue}");
            // If the table is "Location", also remove the record from the database
            if (Name == "Location")
            {
                var entity = _dbContext.Locations.FirstOrDefault(l => l.LocationID == primaryKeyValue);
                if (entity != null)
                {
                    _dbContext.Locations.Remove(entity);
                    _dbContext.SaveChanges();
                }
            }
        }
        // Update a specific field of a record by its primary key value

        public void Update(string primaryKeyValue, string fieldName, object newValue)
        {
            var record = rows.Get(primaryKeyValue);
            if (record != null)
            {
                record[fieldName] = newValue;
                // If the table is "Location", also update the corresponding entity in the database
                if (Name == "Location")
                {
                    var entity = _dbContext.Locations.FirstOrDefault(l => l.LocationID == primaryKeyValue);
                    if (entity != null)
                    {
                        typeof(Location).GetProperty(fieldName)?.SetValue(entity, newValue);
                        _dbContext.SaveChanges();
                    }
                }
            }
            else
            {
                throw new KeyNotFoundException($"Record with key '{primaryKeyValue}' not found.");
            }
        }


        // Retrieve all records from the table
        public IEnumerable<Record> GetAll()
        {
            foreach (var pair in rows.GetAll())
            {
                yield return pair.Value;// Return each record
            }
        }
    }


    // Represents a database that contains multiple tables and can manage them
    public class Database
    {
        private Dictionary<string, Table> tables = new Dictionary<string, Table>();
        // Add a new table to the database
        public void AddTable(Table table)
        {
            tables[table.Name] = table;
        }
        // Retrieve a table by name
        public Table GetTable(string name)
        {
            return tables[name];
        }
        // Print foreign key references between two tables
        public void PrintForeignReference(string fromTableName, string toTableName, string foreignKeyField)
        {
            var fromTable = GetTable(fromTableName);
            var toTable = GetTable(toTableName);

            Console.WriteLine($"\n{fromTableName} referencing {toTableName}:");
            // Iterate through all records in the "from" table and print their references to the "to" table
            foreach (var record in fromTable.GetAll())
            {
                string fk = record[foreignKeyField].ToString();
                var referenced = toTable.Get(fk);
                Console.WriteLine($"{fromTableName} Record: {record["Name"]}, linked to {toTableName} Record: {referenced["Name"]}");
            }
        }
    }
}