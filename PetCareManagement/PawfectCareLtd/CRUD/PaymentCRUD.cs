// Import dependencies.
using System;
using System.Collections.Generic;
using System.Linq;
using PawfectCareLtd.Controllers;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.Models;

namespace PawfectCareLtd.CRUD // Define the namespace for the application.
{
    // Class to encapsulate all of the CRUD operations for the Payment table.
    public class PaymentCRUD
    {
        // Define a field to store a reference to the in-memory database.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;

        // Constructor to initialize the class with an instance of the in-memory database.
        public PaymentCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;
        }

        // Method to insert data into the Payment table.
       
        public OperationResult InsertOperationForPayment(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string ForeignKeyField, string ReferencedTableName)> foreignKeys)
        {
            // Get the payment table from the in-memory database.
            var paymentTable = _inMemoryDatabase.GetTable("Payment");

            // Check if the primary key is present in the input dictionary.
            if (!fieldValues.ContainsKey(primaryKeyName))
            {
                return new OperationResult { success = false, message = "Primary key must be inputted." };
            }

            // Retrieve and convert the primary key to a string.
            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();

            // Check if the primary key is empty or doesn't match the required format.
            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
            {
                return new OperationResult { success = false, message = $"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'." };
            }

            // Check if a record with the same primary key already exists.
            if (paymentTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
            {
                return new OperationResult { success = false, message = $"A record with primary key '{primaryKeyValue}' already exists." };
            }

            // Validate each foreign key against the referenced table.
            foreach (var (foreignKeyField, referencedTableName) in foreignKeys)
            {
                // Skip if the foreign key field is not provided.
                if (!fieldValues.ContainsKey(foreignKeyField)) continue;

                // Retrieve the foreign key value.
                string foreignKeyValue = fieldValues[foreignKeyField]?.ToString();

                // Get the referenced table.
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                // Check if the foreign key exists in the referenced table.
                if (!referencedTable.GetAll().Any(record => record.Fields.Values.Contains(foreignKeyValue)))
                {
                    return new OperationResult { success = false, message = $"Foreign key value '{foreignKeyValue}' not found in table '{referencedTableName}'." };
                }
            }

            var newRecord = new Record();
            foreach (var field in fieldValues)
                newRecord[field.Key] = field.Value;

            try
            {
                // Insert into in-memory table.
                paymentTable.Insert(newRecord, skipDb: true);

                // Insert into SQL database.
                var entity = new Payment();
                foreach (var field in fieldValues)
                {
                    var property = typeof(Payment).GetProperty(field.Key);
                    if (property != null)
                        property.SetValue(entity, Convert.ChangeType(field.Value, property.PropertyType));
                }
                _dbContext.Payments.Add(entity);
                _dbContext.SaveChanges();

                return new OperationResult { success = true, message = "Record inserted successfully into payment table." };
            }
            catch (Exception ex)
            {
                return new OperationResult { success = false, message = $"Failed to insert record: {ex.Message}" };
            }
        }

        // Method to read data from the Payment table.
        public OperationResult ReadOperationForPayment(string fieldName, string fieldValue)
        {
            // Get the Payment table from the in-memory database.
            var paymentTable = _inMemoryDatabase.GetTable("Payment");

            // Check if there are any records that match the search criteria.
            var matchingRecords = paymentTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();

            // Transform the record into a format that can be read into the database.
            var matchingData = matchingRecords.Select(r => r.Fields).ToList();

            // If there are no matches, return a message indicating no results found.
            if (matchingRecords.Count == 0)
            {
                return new OperationResult { success = false, message = $"No records found in table '{paymentTable.Name}' where {fieldName} = '{fieldValue}'." };
            }

            // If there are matches, return the matching records.
            return new OperationResult { success = true, message = "Operation was successful", data = matchingData };
        }

        // Method to update data in the Payment table.
        public OperationResult UpdateOperationForPayment(string primaryKeyValue, string fieldName, string newValue)
        {
            // Get the Payment table from the in-memory database.
            var paymentTable = _inMemoryDatabase.GetTable("Payment");

            // Convert the new value to object type.
            object newValueToObject = newValue;

            // Try updating the data in the Payment table.
            try
            {
                // Update the record in the in-memory database.
                paymentTable.Update(primaryKeyValue, fieldName, newValueToObject);

                // Save to SQL database.
                var paymentEntity = _dbContext.Payments.Find(primaryKeyValue);
                if (paymentEntity != null)
                {
                    var property = typeof(Payment).GetProperty(fieldName);
                    if (property != null)
                    {
                        property.SetValue(paymentEntity, Convert.ChangeType(newValue, property.PropertyType));
                        _dbContext.SaveChanges();
                    }
                }

                return new OperationResult { success = true, message = $"Field '{fieldName}' updated successfully for Payment with primary key '{primaryKeyValue}'." };
            }
            catch (KeyNotFoundException) // Catch any errors related to missing data.
            {
                return new OperationResult { success = false, message = $"No record found with primary key '{primaryKeyValue}' in Payment table." };
            }
            catch (Exception ex) // Catch any other errors.
            {
                return new OperationResult { success = false, message = $"Error updating field: {ex.Message}" };
            }
        }

        // Method for API delete.
        public OperationResult DeletePaymentById(string paymentId)
        {
            var paymentTable = _inMemoryDatabase.GetTable("Payment");

            // Try to delete from in-memory database.
            try
            {
                paymentTable.Delete(paymentId);
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"Payment with ID {paymentId} not found in in-memory database." };
            }

            // Try to delete from SQL Server.
            var paymentEntity = _dbContext.Payments.Find(paymentId);
            if (paymentEntity != null)
            {
                _dbContext.Payments.Remove(paymentEntity);
                _dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Payment with ID {paymentId} not found in SQL database.");
            }

            return new OperationResult { success = true, message = $"Payment with ID {paymentId} deleted from in-memory database." };
        }

        // Method to get all the payment records.
        public OperationResult GetAllPaymentRecord()
        {
            // Get the Payment table from the in-memory database.
            var table = _inMemoryDatabase.GetTable("Payment");

            // Get all records from the Payment table.
            var allPaymentRecord = table.GetAll().Select(record => record.Fields).ToList();

            return new OperationResult { success = true, message = "Operation was successful", data = allPaymentRecord };
        }
    }
}
