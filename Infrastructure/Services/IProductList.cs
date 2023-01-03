using Microsoft.EntityFrameworkCore;
using Domain.Model;

namespace Infrastructure.Services;
public interface IProductListService
{
        public Task<List<ProductList>> GetAllProducts();
        public Task<ProductList> GetSingleProduct(int id);

        public Task<List<ProductList>> AddProduct(ProductList productlist);

        public Task<List<ProductList>> UpdateProduct(ProductList updatedproductlist);

        public Task<ProductList> DeleteProduct(int id);
}
