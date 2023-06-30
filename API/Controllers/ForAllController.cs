using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForAllController : ControllerBase
    {

        private readonly ILogger<ForAllController> _logger;
        private readonly SightseeingdbContext _context;

        public ForAllController(ILogger<ForAllController> logger, SightseeingdbContext context )
        {
            _logger = logger;
            _context = context;
        }
        /*
        [HttpGet]//test method
        public string Get()
        {
            return "Эту страницу может посещатьлюбой пользователь";
        }*/

        [HttpGet]//test method
        public IEnumerable<Ticket> Get()
        {
            return _context.Tickets.ToList();
        }
    }
}