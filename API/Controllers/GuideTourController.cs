using BLL.Models;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuideTourController : ControllerBase
    {
        private readonly IGuideTourService _service;

        public GuideTourController(IGuideTourService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GuideTourDTOModel>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(GuideTourDTOModel model)
        {
            await _service.AddAsync(model);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(uint guideId, uint tourId)
        {
            await _service.DeleteAsync(guideId, tourId);

            return Ok();
        }
    }
}
