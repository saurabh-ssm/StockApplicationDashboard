using DataAccessLayer.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Model;

namespace StockApplicationDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        //[HttpGet]
        //[Route("{id}")]
        //public async Task<IActionResult> GetByIdAync(int id)
        //{
        //    var data = await _stockRepository.GetByIdAsync(id);
        //    return Ok(data);
        //}
        [HttpPost]
        public async Task<IActionResult> AddAsync(StockApi stockApi)
        {
            var data = await _stockRepository.AddAsync(stockApi);
            return Ok(data);
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAllAsync()
        //{
        //    var data = await _stockRepository.GetAllAsync();
        //    return Ok(data);
        //}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _stockRepository.DeleteAsync(id);
            return Ok(data);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, StockApi stockApi)
        {
            var data = await _stockRepository.UpdateAsync(id, stockApi);
            return Ok(data);



        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockApi>>> GetStockPrices()
        {
            var stockPrices = await _stockRepository.GetStockPrices();

            return Ok(stockPrices);
        }
    }
}
