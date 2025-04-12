// Import dependencies.
using System; // Import a base class definition.
using System.Collections.Generic; // To collect generic collections like Dictionary.


namespace PawfectCareLtd.Data.DataRetrieval  // Define the namespace for the application.

{
    // Class that recreate a custom hashtable using separate chaining
    public class HashTable<K, V>
    {
        // Define variable need for the hashtable.
        private const int Size = 101; // Size of the hash table.
        private readonly LinkedList<KeyValuePair<K, V>>[] buckets = new LinkedList<KeyValuePair<K, V>>[Size]; // Array of link list used to store key value pair.


        // Method to calculate the index of the bucket for a given key.
        private int GetIndex(K key) => Math.Abs(key.GetHashCode()) % Size;


        // Method to add a key-value pair to the hashtable.
        public void Add(K key, V value)
        {
            // Get the index from the key.
            int index = GetIndex(key);

            // Check if there are no link list at the current link list, if it does not create one.
            if (buckets[index] == null)
                buckets[index] = new LinkedList<KeyValuePair<K, V>>();

            // Check if the key already exists, throw exception if it does.
            foreach (var pair in buckets[index])
            {
                // Check if the key matches, if it does throw an exception.
                if (EqualityComparer<K>.Default.Equals(pair.Key, key))
                    throw new Exception("Duplicate key");
            }

            // Add the new key-value pair to the bucket.
            buckets[index].AddLast(new KeyValuePair<K, V>(key, value));
        }


        // Method to remove a key-value pair by key.
        public bool Remove(K key)
        {
            // Get the index from the key.
            int index = GetIndex(key);

            // Check if there are any link list at index location.
            if (buckets[index] != null)
            {
                // Get the first node of the list list.
                var node = buckets[index].First;

                // Iterate through the link list until there are no more node.
                while (node != null)
                {
                    // If the key matches.
                    if (EqualityComparer<K>.Default.Equals(node.Value.Key, key))
                    {
                        buckets[index].Remove(node); // Remove the node from the list.
                        return true; // Return true to indicate that the removal of a node has been successful.
                    }
                    node = node.Next; // Get the next node.
                }
            }

            // Return false to indicate that the removal of a node has not been successful.
            return false;
        }


        // Method to get the value for a given key.
        public V Get(K key)
        {
            // Get the index from the key.
            int index = GetIndex(key);

            // Check if there are any link list at index location.
            if (buckets[index] != null)
            {
                foreach (var pair in buckets[index])
                {
                    // If the key matches.
                    if (EqualityComparer<K>.Default.Equals(pair.Key, key))
                        return pair.Value; // Return the key value pair.
                }
            }

            // Throw an exception if any issue was found.
            throw new KeyNotFoundException();
        }


        // Method to check if the key exists in the hashtable.
        public bool ContainsKey(K key)
        {
            // Get the index from the key.
            int index = GetIndex(key);

            // Check if there are any link list at index location.
            if (buckets[index] != null)
            {
                // Iterate through the link list.
                foreach (var pair in buckets[index])
                {
                    // If the key matches.
                    if (EqualityComparer<K>.Default.Equals(pair.Key, key))
                        return true; // Return true to indicate that the key does exist.
                }
            }

            // Return true to indicate that the key does not exist.
            return false;
        }


        // Method to return all key-value pairs stored in the hashtable.
        public IEnumerable<KeyValuePair<K, V>> GetAll()
        {
            // Iterate through the link list.
            foreach (var bucket in buckets)
            {
                // If the bucket is not null, iterate through each bucket and return the key value pair.
                if (bucket != null)
                {
                    foreach (var pair in bucket)
                        yield return pair;
                }
            }
        }
    }
}