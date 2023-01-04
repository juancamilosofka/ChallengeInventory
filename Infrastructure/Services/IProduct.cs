using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Domain.DTO;

namespace Infrastructure.Services;
public interface IProductService
{
        public Task<PaginationProduct> GetAllProducts(int size, int page);
        public Task<Product> GetSingleProduct(int id);

        public Task<Product> AddProduct(Product product);

        public Task<Product> UpdateProduct(Product updatedproduct);

        public Task<Product> DeleteProduct(int id);
}
