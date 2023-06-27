using BLL.Models;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTOModel>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<UserDTOModel>> GetAsync(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(int id, UserDTOModel model)
        {
            if (HttpContext.User.FindFirstValue(ClaimTypes.Role) != "1")
            {
                int tokenUserId = Convert.ToInt32(HttpContext.User.FindFirstValue("UserID"));

                if (tokenUserId != id)
                {
                    return Unauthorized();
                }
            }
            await _service.UpdateAsync(id, model);

            return Ok();
        }

        [HttpPost("id")]
        public async Task<IActionResult> AddAsync(UserDTOModel model)
        {
            await _service.AddAsync(model);

            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}
