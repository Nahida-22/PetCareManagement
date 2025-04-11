using System;
using System.Collections.Generic;

namespace PawfectCareLtd.Data.DataRetrieval.cs

{
    // Custom simple hashtable using separate chaining
    public class HashTable<K, V>
    {
        private const int Size = 101; // Size of the hash table
        private readonly LinkedList<KeyValuePair<K, V>>[] buckets = new LinkedList<KeyValuePair<K, V>>[Size];
        
        // Method to calculate the index of the bucket for a given key
        private int GetIndex(K key) => Math.Abs(key.GetHashCode()) % Size;
        
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

}