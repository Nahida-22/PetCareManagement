// Import dependencies.
using System; // Import a base class definition.
using System.Collections.Generic; // To collect generic collections like Dictionary.

namespace PawfectCareLtd.Data.DataRetrieval // Define the namespace for the application.
{

    // Class that store and manage field value pair.
    public class Record
    {

        // Define a dictionary that will hold the field value pairs.
        public Dictionary<string, object> Fields = new();


        // Indexer to that allows declaration access.
        public object this[string field]
        {
            get => Fields[field]; // Get the value associated with a given field name.
            set => Fields[field] = value; // Set the value associated with a given field name.
        }


        // Method to override the default in-built ToString method.
        public override string ToString()
        {
            var entries = string.Join(", ", Fields); // Concatenates dictionary entries into a single string separeated by a comma.
            return $"{{ {entries} }}"; // Return the formated string.
        }
    }
}