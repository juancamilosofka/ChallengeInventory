using Microsoft.EntityFrameworkCore;
using Domain.Model;

namespace Infrastructure.Services;
public class ProductListService : IProductListService
{
        private readonly DbContext _context;
        public ProductListService(DbContext context)
        {
            _context = context;
        }
        public Task<List<ProductList>> GetAllProducts(){
            return null;
        }
        public Task<ProductList> GetSingleProduct(int id){
            return null;
        }

        public Task<List<ProductList>> AddProduct(ProductList productlist){
            return null;
        }

        public Task<List<ProductList>> UpdateProduct(ProductList updatedproductlist){
            return null;
        }

        public Task<ProductList> DeleteProduct(int id){
            return null;
        }
}
