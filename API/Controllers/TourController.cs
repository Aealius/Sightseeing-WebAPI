using BLL.Models;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TourController : ControllerBase
    {
        private readonly ITourService _service;

        public TourController(ITourService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TourDTOModel>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<TourDTOModel>> GetAsync(uint id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(uint id, TourDTOModel model)
        {
            await _service.UpdateAsync(id, model);

            return Ok();
        }

        [HttpPost("id")]
        public async Task<IActionResult> AddAsync(TourDTOModel model)
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
