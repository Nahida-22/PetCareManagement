//using CsvHelper;
//using PawfectCareLtd.Models;
//using System.Globalization;
//using System.IO;
//using System.Linq;

//public class CsvReaderService
//{
//    private readonly DatabaseContext _context;

//    public CsvReaderService(DatabaseContext context)
//    {
//        _context = context;
//    }

//    // Method to read Owner data from CSV and save it to the database
//    public void ReadOwnersFromCsv(string filePath)
//    {
//        using (var reader = new StreamReader(filePath))
//        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//        {
//            // Read all records from CSV and map them to the Owner class
//            var records = csv.GetRecords<Owner>().ToList();

//            // Add records to the Owners DbSet
//            _context.Owners.AddRange(records);
//            _context.SaveChanges(); // Commit changes to the database
//        }
//    }

    
    
//}
