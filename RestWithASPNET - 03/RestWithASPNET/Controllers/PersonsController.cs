using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Model;
using RestWithASPNET.Services;

namespace RestWithASPNET.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : Controller
    {
        private IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindByAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.FindById(id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null)
                return NotFound();
            return new ObjectResult(_personService.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Person person)
        {
            if (person == null)
                return NotFound();
            return new ObjectResult(_personService.Update(person));

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}