using Laba_7.Models;
using Laba_7.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laba_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var characters = await _salesService.GetAllAsync();
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var character = await _salesService.GetByIdAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Sales sales)
        {
            return Ok(sales);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Sales sales)
        {
            if (id != sales.Id)
            {
                return BadRequest();
            }

            await _salesService.UpdateAsync(sales);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _salesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
