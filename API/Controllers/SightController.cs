using BLL.Models;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class SightController : ControllerBase
    {
        private readonly ISightService _service; 

        public SightController(ISightService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SightDTOModel>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<SightDTOModel>> GetAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Does not exist");
            }

            return Ok();
        }

        [Authorize(Roles = "1")]
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(int id, SightDTOModel model)
        {
            await _service.UpdateAsync(id, model);

            return Ok();
        }

        [Authorize(Roles = "1")]
        [HttpPost("id")]
        public async Task<IActionResult> AddAsync(SightDTOModel model)
        {
            await _service.AddAsync(model);

            return Ok();
        }

        [Authorize(Roles = "1")]
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}
