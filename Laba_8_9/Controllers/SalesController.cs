using Laba_7.Models;
using Laba_7.Services;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laba_7.Controllers
{
    [ApiController]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Obsolete]
        public IActionResult GetAllAsyncV1()
        {
            return Ok(123);
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public IActionResult GetAllAsyncV2()
        {
            return Ok("This is version 2.0");
        }
        [HttpGet]
        [MapToApiVersion("3.0")]
        public async Task<IActionResult> GetAllAsyncV3()
        {
            var sales = await _salesService.GetAllAsync();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sales");

            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Price";
            worksheet.Cell(1, 3).Value = "Pharm ID";

            int i = 2;
            foreach (var sale in sales)
            {
                worksheet.Cell(i, 1).Value = sale.Id;
                worksheet.Cell(i, 2).Value = sale.price;
                worksheet.Cell(i, 3).Value = sale.PharmId;
                i++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Sales.xlsx");
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
