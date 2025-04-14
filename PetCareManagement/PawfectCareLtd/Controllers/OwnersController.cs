using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using PawfectCareLtd.Data;
using PawfectCareLtd.Models;
using Microsoft.AspNetCore.Http;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.CRUD;
using PawfectCareLtd.Helpers;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;


namespace PawfectCareLtd.Controllers
{
    // OwnersController.cs in PawfectCareLtd.API
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly Database _database;
        private readonly OwnerCRUD _ownerCRUD;

        public OwnersController(Database database, OwnerCRUD ownerCRUD)
        {
            _database = database;
            _ownerCRUD = ownerCRUD;
        }

        [HttpGet]
        public IActionResult GetAllOwners()
        {
            var ownersTable = _database.GetTable("Owner");

            var ownersList = ownersTable.GetAll().Select(r => new
            {
                ID = r["OwnerID"],
                FirstName = r["FirstName"],
                LastName = r["LastName"]
            }).ToList();

            return Ok(ownersList);
        }


        /// <summary>
        /// 
        /// API for Search
        /// Allows search based on multiple fields
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("search")] 
        public IActionResult SearchOwners([FromQuery] Dictionary<string, string> query)
        {
            if (query.Count == 0)
                return BadRequest("Please provide at least one search field and value.");

            // Define expected field types (optional: you can also make this dynamic later)
            var fieldTypes = new Dictionary<string, string>
            {
                { "OwnerID", "string" },
                { "FirstName", "string" },
                { "LastName", "string" },
                { "Email", "string" },
                { "PhoneNo", "string" },
                { "Address", "string" }

            };

            // Filter the query only to include valid fields from your system
            var searchFields = query
                .Where(q => fieldTypes.ContainsKey(q.Key) && !string.IsNullOrEmpty(q.Value))
                .ToDictionary(q => q.Key, q => q.Value);

            if (searchFields.Count == 0)
                return BadRequest("None of the provided fields are valid or non-empty.");

            var helper = new InMemorySearchHelper(_database);
            var results = helper.FindRecordsByFields("Owner", searchFields);

            if (results.Count == 0)
                return NotFound("No matching owners found.");

            return Ok(results);
        }

        [HttpPost]
        public IActionResult AddOwner([FromBody] OwnerDto owner)
        {
            var ownersTable = _database.GetTable("Owner");
            var record = new Record
            {
                ["OwnerID"] = owner.ID,
                ["FirstName"] = owner.FirstName,
                ["LastName"] = owner.LastName
            };

            ownersTable.Insert(record);
            return Ok();
        }

        // Api for Deletion.
        [HttpDelete("{ownerId}")]
        public IActionResult DeleteOwner(string ownerId)
        {
            try
            {
                var deleted = _ownerCRUD.DeleteOwnerById(ownerId);
                return Ok($"Owner {ownerId} and associated pets deleted successfully.");
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

    public class OwnerDto
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

