﻿using BLL.Models;
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
        public async Task<ActionResult<SightDTOModel>> GetAsync(uint id)
        {
            await _service.GetByIdAsync(id);

            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(uint id, ReviewDTOModel model)
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
        public async Task<IActionResult> DeleteAsync(uint id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}
