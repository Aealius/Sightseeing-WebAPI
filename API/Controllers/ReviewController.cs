using BLL.Models;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase 
    {
        private readonly IReviewService _service;

        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReviewDTOModel>>> GetAllAsync()
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

        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(int id, ReviewDTOModel model)
        {
            await _service.UpdateAsync(id, model);

            return Ok();
        }

        [HttpPost("id")]
        public async Task<IActionResult> AddAsync(ReviewDTOModel model)
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
