using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiprojectWithDb.API.DTOs;
using MultiprojectWithDb.DTOs;
using MultiprojectWithDB.BusinessLogic.BL_Interfaces;
using MultiprojectWithDB.BusinessLogic.BL_Services;
using MultiprojectWithDB.MAIN.DTOs;
using System.Net.Mime;

namespace MultiprojectWithDb.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IUserMapper _userMapper;

        public UserController(ILogger<WeatherForecastController> logger, IUserService userService, IJwtService jwtService, IUserMapper userMapper)
        {
            _logger = logger;
            _userService = userService;
            _jwtService = jwtService;
            _userMapper = userMapper;
        }



        // =================================== CONTROLLER METHODS ===================================

        [HttpPost("Login")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login(UserGetDTO request)
        {
            var response = _userService.Login(request.Username, request.Password, out string role);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            var jwtToken = _jwtService.GetJwtToken(request.Username, role);
            return Ok(jwtToken);//token grazint yra geriau nei trylogin bool
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserCreateDTO request)// geriau atsiakyti sjp dto, ir turert metodiska - UserCreateDTO
        {
            var response = _userService.Register(request.Username, request.Password);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return Ok();
        }

        //visada reikėtu naudoti IActionResult kai daroma xml dokumentacija
        //jei dokumentacija nedaroma, tada reikėtu naudoti ActionResult<T>

        //[HttpPost("Register")]
        //public ActionResult<UserResponseDTO> Register([FromBody] UserDTO request)
        //{
        //    var response = _userService.Register(request.Username, request.Password);
        //    if (!response.IsSuccess)
        //    {
        //        return BadRequest(response.Message);
        //    }
        //    return response;
        //}
    }
}
