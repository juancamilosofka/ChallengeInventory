using Microsoft.EntityFrameworkCore;
using Domain.Model;

namespace Infrastructure.Services;
public interface IProductService
{
        public Task<ProductPagination> GetAllProducts(int size, int page);
        public Task<Product> GetSingleProduct(int id);

        public Task<List<Product>> AddProduct(Product product);

        public Task<List<Product>> UpdateProduct(Product updatedproduct);

        public Task<Product> DeleteProduct(int id);
}
