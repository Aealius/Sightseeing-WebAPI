using BLL.Models;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TourSightController : ControllerBase
    {
        private readonly ITourSightService _service;

        public TourSightController(ITourSightService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TourSightDTOModel>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TourSightDTOModel model)
        {
            await _service.AddAsync(model);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(uint tourId, uint sightId)
        {
            await _service.DeleteAsync(tourId, sightId);

            return Ok();
        }
    }
}
