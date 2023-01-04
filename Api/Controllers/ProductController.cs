using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Model;
using Domain.DTO;
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
            
            PaginationProduct productsPage = await _service.GetAllProducts(size, page);

            if(productsPage == null){
                return NoContent();
            }

            return Ok(productsPage);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetSingleProduct( int id){
            
            var product = await _service.GetSingleProduct(id);

            if(product == null){
                return NotFound("Product not found");
            }

         return Ok(product);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct( int id){
            
            var product = await _service.DeleteProduct(id);

            if(product == null){
                return NotFound("Product not found");
            }

         return Ok($"Product {product.IdProduct} deleted");
        }

        [HttpPost("Post")]
        public async Task<IActionResult> AddProduct(Product newproduct){
            
            var product = await _service.AddProduct(newproduct);

            if(product == null){
                return BadRequest("Error. Product was not added");
            }

         return Ok(newproduct);
        }

        [HttpPut("Put")]
        public async Task<IActionResult> UpdateProduct(Product updatedproduct){
            
            var product = await _service.UpdateProduct(updatedproduct);

            if(product == null){
                return NotFound("Product not found");
            }

         return Ok(updatedproduct);
        }
    }
}
