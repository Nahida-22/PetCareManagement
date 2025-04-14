using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using PawfectCareLtd.Data;
using PawfectCareLtd.Models;
using Microsoft.AspNetCore.Http;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.CRUD;
using PawfectCareLtd.Helpers;

namespace PawfectCareLtd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly Database _database;
        private readonly SupplierCRUD _supplierCRUD;

        public SuppliersController(Database database, SupplierCRUD supplierCRUD)
        {
            _database = database;
            _supplierCRUD = supplierCRUD;
        }

        [HttpGet]
        public IActionResult GetAllSuppliers()
        {
            var supplierTable = _database.GetTable("Supplier");

            var supplierList = supplierTable.GetAll().Select(r => new
            {
                ID = r["SupplierID"],
                Name = r["Name"],
                Email = r["Email"]
            }).ToList();

            return Ok(supplierList);
        }

        [HttpGet("search")]
        public IActionResult SearchSuppliers([FromQuery] Dictionary<string, string> query)
        {
            if (query.Count == 0)
                return BadRequest("Please provide at least one search field and value.");

            var fieldTypes = new Dictionary<string, string>
            {
                { "SupplierID", "string" },
                { "Name", "string" },
                { "Email", "string" },
                { "PhoneNo", "string" },
                { "Address", "string" }
            };

            var searchFields = query
                .Where(q => fieldTypes.ContainsKey(q.Key) && !string.IsNullOrEmpty(q.Value))
                .ToDictionary(q => q.Key, q => q.Value);

            if (searchFields.Count == 0)
                return BadRequest("None of the provided fields are valid or non-empty.");

            var helper = new InMemorySearchHelper(_database);
            var results = helper.FindRecordsByFields("Supplier", searchFields);

            if (results.Count == 0)
                return NotFound("No matching suppliers found.");

            return Ok(results);
        }

        [HttpPost]
        public IActionResult AddSupplier([FromBody] SupplierDto supplier)
        {
            var supplierTable = _database.GetTable("Supplier");
            var record = new Record
            {
                ["SupplierID"] = supplier.ID,
                ["Name"] = supplier.Name,
                ["Email"] = supplier.Email
            };

            supplierTable.Insert(record);
            return Ok();
        }

        [HttpDelete("{supplierId}")]
        public IActionResult DeleteSupplier(string supplierId)
        {
            try
            {
                var deleted = _supplierCRUD.DeleteSupplierById(supplierId);
                return Ok($"Supplier {supplierId} and associated data deleted successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

    public class SupplierDto
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
