using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize("OnlyAdmin")] // контроллер доступен только администратору
    [Authorize]          // контроллер доступен всем пользователям
    public class UserController : Controller
    {
        private readonly SightseeingdbContext _context;

        public UserController(SightseeingdbContext context)
        {
            _context = context;
        }
        /*
        [HttpGet]//test method
        public string Get()
        {
            return "Эту страницу могут посещать только авторизованные пользователи";
        }*/

        [HttpGet]//test method
        public IEnumerable<Guide> Get()
        {
            return _context.Guides.ToList();
        }

    }
}
