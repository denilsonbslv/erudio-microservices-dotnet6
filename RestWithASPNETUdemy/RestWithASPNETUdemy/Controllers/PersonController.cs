using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Helpers;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_personService.GetAll());
        }

        [HttpGet("GetById/{idPerson}")]
        public IActionResult GetById(long idPerson)
        {
            var person = _personService.GetById(idPerson);
            if (person != null)
                return Ok(person);
            else
                return NotFound();
        }
    
        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person != null)
                return Ok(_personService.Create(person));
            else
                return BadRequest();
        }
    
        [HttpPut("{idPerson}")]
        public IActionResult Delete(long idPerson)
        {
            _personService.Delete(idPerson);
            return NoContent();
        }
    }
}
