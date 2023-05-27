using Laba_7.Models;
using Laba_7.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Laba_7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PharmController : ControllerBase
    {
        private readonly IPharmService _pharmService;

        public PharmController(IPharmService pharmService)
        {
            _pharmService = pharmService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var pharmas  = await _pharmService.GetAllAsync();
            return Ok(pharmas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var pharma = await _pharmService.GetByIdAsync(id);
            if (pharma == null)
            {
                return NotFound();
            }
            return Ok(pharma);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Pharma pharma)
        {
            return Ok(pharma);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Pharma pharma)
        {
            if (id != pharma.Id)
            {
                return BadRequest();
            }

            await _pharmService.UpdateAsync(pharma);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _pharmService.DeleteAsync(id);
            return NoContent();
        }
    }
}
