using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiprojectWithDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public UserController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // =================================== CONTROLLER METHODS ===================================


    }
}
