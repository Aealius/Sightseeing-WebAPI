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
        public async Task<ActionResult<SightDTOModel>> GetAsync(uint id)
        {
            await _service.GetByIdAsync(id);

            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(uint id, SightDTOModel model)
        {
            await _service.UpdateAsync(id, model);

            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpPost("id")]
        public async Task<IActionResult> AddAsync(SightDTOModel model)
        {
            await _service.AddAsync(model);

            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(uint id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}
