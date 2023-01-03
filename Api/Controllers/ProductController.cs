using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Model;
using Infrastructure.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

                [HttpGet("Get/{size}/{page}")]
        public async Task<IActionResult> GetProductsByPage( int size, int page){
            
            ProductPagination productsPage = await _service.GetAllProducts(size, page);

            if(productsPage == null){
                return NoContent();
            }

            return Ok(productsPage);
        }

    }
}
