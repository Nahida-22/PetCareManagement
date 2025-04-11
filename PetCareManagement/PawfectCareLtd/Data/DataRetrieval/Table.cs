using System;
using System.Collections.Generic;
using System.Linq;
using PawfectCareLtd.Data.DataRetrieval.cs;
using PawfectCareLtd.Models;

namespace PawfectCareLtd.Data.DataRetrieval
{
    public class Table
    {
        private readonly HashTable<string, Record> rows = new();
        public string Name { get; }
        private readonly string primaryKey;
        private readonly DatabaseContext _dbContext;

        public Table(string name, string primaryKeyField, DatabaseContext dbContext)
        {
            Name = name;
            primaryKey = primaryKeyField;
            _dbContext = dbContext;
        }

        public void Insert(Record record, bool skipDb = false)
        {
            string key = record[primaryKey].ToString();
            rows.Add(key, record);

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

        public Record Get(string primaryKeyValue) => rows.Get(primaryKeyValue);

        public void Delete(string primaryKeyValue)
        {
            if (!rows.Remove(primaryKeyValue))
                throw new KeyNotFoundException($"No record found with key: {primaryKeyValue}");

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

        public void Update(string primaryKeyValue, string fieldName, object newValue)
        {
            var record = rows.Get(primaryKeyValue);
            if (record != null)
            {
                record[fieldName] = newValue;

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

        public IEnumerable<Record> GetAll()
        {
            foreach (var pair in rows.GetAll())
                yield return pair.Value;
        }
    }
}