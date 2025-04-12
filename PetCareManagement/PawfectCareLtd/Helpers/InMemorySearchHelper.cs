using PawfectCareLtd.Data.DataRetrieval;

namespace PawfectCareLtd.Helpers
{
    public class InMemorySearchHelper
    {
        private readonly Database _inMemoryDatabase;

        public InMemorySearchHelper(Database inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public List<Dictionary<string, object>> FindRecordsByFields(string tableName, Dictionary<string, string> searchFields)
        {
            var table = _inMemoryDatabase.GetTable(tableName);

            var matchingRecords = table.GetAll()
                .Where(record =>
                    searchFields.All(kv =>
                        record.Fields.ContainsKey(kv.Key) &&
                        record[kv.Key]?.ToString() == kv.Value
                    )
                )
                .Select(record => record.Fields.ToDictionary(f => f.Key, f => f.Value))
                .ToList();

            return matchingRecords;
        }
    }
}


