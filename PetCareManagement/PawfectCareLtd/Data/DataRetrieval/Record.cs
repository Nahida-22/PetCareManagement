using System;
using System.Collections.Generic;

namespace PawfectCareLtd.Data.DataRetrieval
{
    public class Record
    {
        public Dictionary<string, object> Fields = new();

        public object this[string field]
        {
            get => Fields[field];
            set => Fields[field] = value;
        }

        public override string ToString()
        {
            var entries = string.Join(", ", Fields);
            return $"{{ {entries} }}";
        }
    }
}