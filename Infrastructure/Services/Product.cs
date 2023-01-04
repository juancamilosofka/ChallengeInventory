using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Domain.DTO;

using Infrastructure.Data;

namespace Infrastructure.Services;
public class ProductService : IProductService
{
    private readonly DBContext _context;
    public ProductService(DBContext context)
    {
        _context = context;
    }
    public async Task<PaginationProduct> GetAllProducts(int size, int page)
    {

        if (_context.product == null)
        {
            return null;
        }

        var pageResults = (float)size;
        var pageCount = Math.Ceiling(_context.product
                                        .Where(p => p.enabled == true)
                                        .Count() / pageResults);

        var productsInPage = await _context.product
                    .Where(p => p.enabled == true)
                    .Skip((page - 1) * (int)pageResults)
                    .Take((int)pageResults)
                    .ToListAsync();

        var pagination = new PaginationProduct
        {

            CurrentPage = page,
            Pages = (int)pageCount,
            PageSize = size,
            products = productsInPage
        };

        return pagination;
    }
    public async Task<Product> GetSingleProduct(int id)
    {

          var find = _context.product.Where(p => p.enabled == true && p.IdProduct == id).Count();
          if (find == 0)                          
        {
            return null;
        }
        var product = await _context.product
                                        .Where(p => p.enabled == true && p.IdProduct == id)
                                        .FirstAsync();
        return product;
    }

    public async Task<Product> AddProduct(Product product)
    {
        try{
            _context.product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }catch{
            return null;
        }

    }

    public async Task<Product> UpdateProduct(Product updatedproduct)
    {
          var find = _context.product.Where(p => p.enabled == true && p.IdProduct == updatedproduct.IdProduct).Count();
          if (find == 0)                          
        {
            return null;
        }
        var product = await _context.product
                                        .Where(p => p.enabled == true && p.IdProduct == updatedproduct.IdProduct)
                                        .FirstAsync();

        product.enabled = updatedproduct.enabled;
        product.inInventory = updatedproduct.inInventory;
        product.Name = updatedproduct.Name;
        product.max = updatedproduct.max;
        product.min = updatedproduct.min;

        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> DeleteProduct(int id)
    {
          var find = _context.product.Where(p => p.enabled == true && p.IdProduct == id).Count();
          if (find == 0)                          
        {
            return null;
        }
        var product = await _context.product
                                        .Where(p => p.enabled == true && p.IdProduct == id)
                                        .FirstAsync();

        product.enabled = false;

        await _context.SaveChangesAsync();
        return product;
    }
}
