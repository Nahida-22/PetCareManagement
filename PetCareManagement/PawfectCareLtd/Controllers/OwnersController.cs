using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using PawfectCareLtd.Data;
using PawfectCareLtd.Models;
using Microsoft.AspNetCore.Http;
using PawfectCareLtd.Data.DataRetrieval;


namespace PawfectCareLtd.Controllers
{
    // OwnersController.cs in PawfectCareLtd.API
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly Database _database;

        public OwnersController(Database database)
        {
            _database = database;
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
    }

    public class OwnerDto
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}

