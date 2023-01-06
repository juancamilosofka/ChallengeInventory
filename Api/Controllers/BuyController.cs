using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Model;
using Domain.DTO;
using Infrastructure.Services;

namespace Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BuyController : ControllerBase
    {
                private readonly IBuyService _service;

        public BuyController(IBuyService service)
        {
            _service = service;
        }

                [HttpPost]
        public async Task<IActionResult> AddBuy(Buy newBuy){
            
            var product = await _service.AddBuy(newBuy);

            if(product == null){
                return BadRequest("Error. Buy was not added");
            }

         return Ok(newBuy);
        }

                [HttpGet("Buyer/{type}/{id}")]
        public async Task<IActionResult> GetBuyByBuyerId(string type, string id){
            
            var product = await _service.GetBuyByBuyerId(type, id);

            if(product == null){
                return NotFound("Buys not found");
            }

         return Ok(product);
        }


    }
}
