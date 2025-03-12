
﻿using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using PawfectCareLtd.Data;
using PawfectCareLtd.Models;
using Microsoft.AspNetCore.Http;

namespace PawfectCareLtd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OwnerController : ControllerBase
    {
        private readonly DatabaseContext ownerContext;

        public OwnerController(DatabaseContext ownerContext)
        {
            this.ownerContext = ownerContext;
        }

        [HttpGet]
        [Route("GetOwners")]
        public List<Owner> GetOwners()
        {
            return ownerContext.Owner.ToList();
        }

        [HttpPost]
        [Route("AddOwners")]

        public string AddOwner(Owner owner)
        {
            string response = string.Empty;
            ownerContext.Owner.Add(owner);
            ownerContext.SaveChanges();
            return "Owner added";
        }
    }
}

