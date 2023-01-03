using Microsoft.EntityFrameworkCore;
using Domain.Model;

using Infrastructure.Data;

namespace Infrastructure.Services;
public class ProductService : IProductService
{
        private readonly DBContext _context;
        public ProductService(DBContext context)
        {
            _context = context;
        }
        public async Task<ProductPagination> GetAllProducts(int size, int page){

            if (_context.product == null){
                 return null;
            }

            var pageResults = (float)size;
            var pageCount = Math.Ceiling(_context.product.Count()/pageResults);

            var productsInPage = await _context.product
                        .Skip((page - 1)*(int)pageResults)
                        .Take((int)pageResults)
                        .ToListAsync();

            var pagination = new ProductPagination{
            
            CurrentPage = page,
            Pages = (int)pageCount,
            products = productsInPage
            };

            return pagination;
        }
        public Task<Product> GetSingleProduct(int id){
            return null;
        }

        public Task<List<Product>> AddProduct(Product product){
            return null;
        }

        public Task<List<Product>> UpdateProduct(Product updatedproduct){
            return null;
        }

        public Task<Product> DeleteProduct(int id){
            return null;
        }
}
