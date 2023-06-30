using BLL.Models;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleDTOModel>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<RoleDTOModel>> GetAsync(uint id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(uint id, RoleDTOModel model)
        {
            await _service.UpdateAsync(id, model);

            return Ok();
        }

        [HttpPost("id")]
        public async Task<IActionResult> AddAsync(RoleDTOModel model)
        {
            await _service.AddAsync(model);

            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(uint id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}
