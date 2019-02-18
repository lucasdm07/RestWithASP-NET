using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Business;
using RestWithASPNET.Data.VO;
using System;
using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : Controller
    {
        private IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindByAll());
        }

        // GET api/values
        [HttpGet("find-with-paged-search/{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetPagedSearch([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return new OkObjectResult(_personBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }
        

        // GET api/values
        [HttpGet("find-by-name")]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetByName([FromQuery]string firstName, [FromQuery]string lastName )
        {
            return Ok(_personBusiness.FindByName(firstName, lastName));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(PersonVO))] // 201 é um created
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]PersonVO personVO)
        {
            if (personVO == null)
                return NotFound();
            return new ObjectResult(_personBusiness.Create(personVO));
        }

        // PUT api/values/5
        [HttpPut] //usada para realizar update
        [ProducesResponseType((202), Type = typeof(PersonVO))] // 202 operacao efetuada com sucesso
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put(int id, [FromBody]PersonVO personVO)
        {
            if (personVO == null)
                // return BadRequest();
                return NotFound();
            var updatedPerson = _personBusiness.Update(personVO);
            if (updatedPerson == null)
                return NoContent();
            return new ObjectResult(updatedPerson);
        }
        // Patch api/values/5
        [HttpPatch] //usada para realizar update
        [ProducesResponseType((202), Type = typeof(PersonVO))] // 202 operacao efetuada com sucesso 
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Patch(int id, [FromBody]PersonVO personVO)
        {
            if (personVO == null)
                // return BadRequest();
                return NotFound();
            var updatedPerson = _personBusiness.Update(personVO);
            if (updatedPerson == null)
                return NoContent();
            return new ObjectResult(updatedPerson);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}