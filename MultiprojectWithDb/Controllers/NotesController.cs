using Microsoft.AspNetCore.Mvc;
using MultiprojectWithDb.DTOs;
using MultiprojectWithDB.BusinessLogic.BL_Interfaces;
using MultiprojectWithDB.DataAccessLayer.DBInterfaces;
using MultiprojectWithDB.DataAccessLayer.DBRepositories;
using MultiprojectWithDB.DataAccessLayer.Entities;
using MultiprojectWithDB.MAIN.DTOs;
using System.Net.Mime;
using System.Security.Claims;


namespace MultiprojectWithDb.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class NotesController : ControllerBase
    {
        //privalomi dto
        //requestDto: post/put - createDto/updateDto
        //responseDto: get - responseDTO

        //userRequest = UserCreateDTO
        //userResponse = UserGetDTO


        private readonly ILogger<NotesController> _logger;
        //private readonly INotesDBRepository _NotesDBRepository;
        private readonly INoteMapper _noteMapper;
        //private readonly IUsersDBRepository _UsersDBRepository;
        private readonly INoteService _noteService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NotesController(ILogger<NotesController> logger,
            INoteMapper noteMapper,
            INoteService noteService,
            IUserService userService, IHttpContextAccessor contextAccessor
            )
        {
            _logger = logger;
            _noteMapper = noteMapper;
            _noteService = noteService;
            _userService = userService;
            _httpContextAccessor = contextAccessor;
        }

        //PUT 

        // =================================== CONTROLLER METHODS ===================================


        // GET: api/<NotesController>
        [HttpGet("GetAllNotesFromUser")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<NoteGetDTO>), StatusCodes.Status200OK)]
        //[Consumes(MediaTypeNames.Application.Json)] - GET nieko neima, tik duoda
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllNotesFromUser()
        {
            var userId = _userService.GetCurrentUserId();

            List<Note> userNotes = _noteService.GetUserNotes(userId).ToList();
            var noteDTO = _noteMapper.Map(userNotes, userId);

            return Ok(noteDTO);

        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]//  skliaustai turi sutapti su metodo parametru! ===================
        [Produces(MediaTypeNames.Application.Json)]
        //[Consumes(MediaTypeNames.Application.Json)]- GET nieko neima, tik duoda
        //[ProducesResponseType(typeof(GetToDoItemDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetNoteById(int id)
        {
            //userId turi ateit is JWT token claim
            //istrint userId is parametru, naudoti contextaccessor


            var data = _noteService.GetNoteById(id);
            if (data == null)
            {
                return NotFound();
            }
            var dto = _noteMapper.Map(data, id);
            return Ok(dto);
        }



        // POST api/<NotesController>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult CreateNewNote(NoteCreateDTO dto)
        {
            var userId = _userService.GetCurrentUserId();

            var note = _noteMapper.Map(dto, userId);
            var noteId = _noteService.AddNewNote(note);

            return Created(nameof(GetNoteById), new { id = noteId });//nuoroda kur ir kaip gauti sukurta irasa, i property id, idedam noteId
            //privalo sutapti su {id} kvieciamam metode
        }



        // PUT api/<NotesController>/5
        /// <summary>
        /// Updates Note
        /// </summary>
        /// <param name="dto">note dto</param>
        /// <returns>no content</returns>
        [HttpPut("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateNote(NoteUpdateDTO dto)
        {
            //userId turi ateit is JWT token claim
            //istrint userId is parametru, naudoti contextaccessor

            var userId = _userService.GetCurrentUserId();
            var entity = _noteMapper.Map(dto, userId);


            _noteService.UpdateNote(entity, userId);

            return NoContent();
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int noteId)
        {
            var userId = _userService.GetCurrentUserId();

            _noteService.RemoveNote(noteId);
            return NoContent();

        }
    }
}
