using BLL.Models;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuideController : ControllerBase 
    {
        private readonly IGuideService _service;

        public GuideController(IGuideService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GuideDTOModel>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<GuideDTOModel>> GetAsync(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(int id, GuideDTOModel model)
        {
            await _service.UpdateAsync(id, model);

            return Ok();
        }

        [HttpPost("id")]
        public async Task<IActionResult> AddAsync(GuideDTOModel model)
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
