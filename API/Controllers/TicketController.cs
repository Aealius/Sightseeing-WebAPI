using BLL.Models;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TicketDTOModel>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetAsync(uint id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Does not exist");
            }

            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(uint id, TicketDTOModel model)
        {
            await _service.UpdateAsync(id, model);

            return Ok();
        }

        [HttpPost("id")]
        public async Task<ActionResult> AddAsync(TicketDTOModel model)
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
