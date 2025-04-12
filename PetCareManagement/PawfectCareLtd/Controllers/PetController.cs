using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using PawfectCareLtd.Data.DataRetrieval;
using Microsoft.AspNetCore.Http;
using PawfectCareLtd.CRUD;
using PawfectCareLtd.Models;
using PawfectCareLtd.Helpers;


namespace PawfectCareLtd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PetController : ControllerBase
    {
        private readonly Database _database;
        private readonly PetCRUD _petCRUD;

        // Constructor.
        public PetController(Database database, PetCRUD petCRUD)
        {
            _database = database;
            _petCRUD = petCRUD;
        }

        [HttpGet] // Get all pets.
        public IActionResult GetAllOwners()
        {
            var petTable = _database.GetTable("Pet");
            var petsList = petTable.GetAll().Select(r => new
            {
                ID = r["PetID"],
                OwnerID = r["OwnerID"],
                PetName = r["PetName"],
                PetType = r["PetType"],
                Breed = r["Breed"],
                Age = r["Age"]

            }).ToList();

            return Ok(petsList);
        }

        [HttpGet("search")]
        public IActionResult SearchOwners([FromQuery] Dictionary<string, string> query)
        {
            if (query.Count == 0)
                return BadRequest("Please provide at least one search field and value.");

            // Define expected field types (optional: you can also make this dynamic later)
            var fieldTypes = new Dictionary<string, string>
            {
                { "PetID", "string" },
                { "OwnerID", "string" },
                { "PetName", "string" },
                { "PetType", "string" },
                { "Breed", "string" },
                { "Age", "int" }
            };

            // Filter the query only to include valid fields from your system
            var searchFields = query
                .Where(q => fieldTypes.ContainsKey(q.Key) && !string.IsNullOrEmpty(q.Value))
                .ToDictionary(q => q.Key, q => q.Value);

            if (searchFields.Count == 0)
                return BadRequest("None of the provided fields are valid or non-empty.");

            var helper = new InMemorySearchHelper(_database);
            var results = helper.FindRecordsByFields("Pet", searchFields);

            if (results.Count == 0)
                return NotFound("No matching pets found.");

            return Ok(results);
        }

        // Api for Deletion.
        [HttpDelete("{petId}")]
        public IActionResult DeletePet(string petId)
        {
            try
            {
                var deleted = _petCRUD.DeletePetById2(petId);
                return Ok($"Owner {petId} and associated pets deleted successfully.");
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
}
