using DAL.Entities;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize("OnlyAdmin")] // контроллер доступен только администратору
    //[Authorize]          // контроллер доступен всем пользователям
    public class AdminController : Controller
    {
        private readonly SightseeingdbContext _context;

        public AdminController(SightseeingdbContext context)
        {
            _context = context;
        }
        /*
        [HttpGet]//test method
        public string Get()
        {
            return "Эту страницу может посещать только Администратор";
        }*/

        [HttpGet]//test method
        public IEnumerable<Ticket> Get()
        {
            return _context.Tickets.ToList();
        }
    }
}
