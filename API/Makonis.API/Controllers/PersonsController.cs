using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Makonis.API.ViewModels;
using Makonis.Contracts.Entities;
using Makonis.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Makonis.API.Controllers
{
    public class PersonsController : BaseAPIController
    {
        private readonly ILogger<PersonsController> _logger;
        private readonly IPersonRepository _repo;
        private readonly IMapper _mapper;

        public PersonsController(IPersonRepository personRepo, ILogger<PersonsController> logger, IMapper mapper)
        {
            _logger = logger;
            _repo = personRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPersons()
        {
            var persons = _repo.GetList();
            if (persons is null) return NotFound("No persons found");
            return Ok(_repo.GetList());
        }

        [HttpPost]
        public IActionResult PostPerson([FromBody] PersonVM personVM)
        {
            //throw new Exception("Testing ");
            if (personVM is null || !ModelState.IsValid)
            {
                _logger.LogError("Person is null");
                return BadRequest("Please provide Person Data");
            }
            //var person = new Person { FirstName = personVM.FirstName, LastName = personVM.LastName };
            var person = _mapper.Map<Person>(personVM);
            _logger.LogInformation("Adding person");
            _repo.Add(person);
            return Created(person.Id.ToString(), person);
        }
    }
}
