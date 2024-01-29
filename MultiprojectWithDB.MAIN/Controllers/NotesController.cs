using Microsoft.AspNetCore.Mvc;
using MultiprojectWithDB.DataAccessLayer.DBInterfaces;
using MultiprojectWithDB.DataAccessLayer.DBRepositories;
using System.Net.Mime;


namespace MultiprojectWithDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ILogger<NotesController> _logger;
        private readonly INotesDBRepository _NotesDBRepository;

        public NotesController(ILogger<NotesController> logger, INotesDBRepository notesDBRepository)
        {
            _logger = logger;
            _NotesDBRepository = notesDBRepository;
        }

        // =================================== CONTROLLER METHODS ===================================


        // GET: api/<NotesController>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(typeof(GetToDoItemDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var data = _NotesDBRepository.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);//cia reiks maperio
        }

        // POST api/<NotesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
