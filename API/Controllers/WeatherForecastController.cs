using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly SightseeingdbContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, SightseeingdbContext context )
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]//test method
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }
    }
}