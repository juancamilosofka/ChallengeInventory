        using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Infrastructure.Data;

namespace Infrastructure.Services;
public class QuantityValidator 
{       
      private readonly DBContext _context;
    public QuantityValidator(DBContext context)
    {
        _context = context;
    }
          public async Task<bool> validator(Buy buy){
          foreach(ProductList p in buy.ProductList){

          var find = _context.product.Where(p => p.enabled == true && p.IdProduct == p.IdProduct).Count();
          if (find == 0)                          
          {
            return false;
          }
          var product = await _context.product
                                   .Where(p => p.enabled == true && p.IdProduct == p.IdProduct)
                                   .FirstAsync();

          if(p.Quantity >= product.max || p.Quantity <= product.min){
                return false;
          }
          }
          return true;
          }

}