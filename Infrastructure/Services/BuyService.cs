using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Infrastructure.Data;

namespace Infrastructure.Services;
public class BuyService  : IBuyService
{
        private readonly DBContext _context;
        public BuyService(DBContext context)
        {
            _context = context;
        }

        public async Task<List<Buy>> GetAllBuys(){
            return null;
        }

        public Task<Buy> GetSingleBuy(int id){
             return null;
        }

     public async Task<List<Buy>> GetBuyByBuyerId(string type, string id){
             
          var find = _context.buy.Where(b => b.Id == id && b.IdType == type).Count();
          if (find == 0)                          
        {
            return null;
        }
        var buys = await _context.buy
                                        .Where(b => b.Id == id)
                                        .ToListAsync();
        return buys;
        }

        public async Task<Buy> AddBuy(Buy buy){
        try{

          foreach(ProductList producToBuy in buy.ProductList){

          var find = _context.product.Where(p => p.enabled == true 
          && p.IdProduct == producToBuy.IdProduct).Count();
          if (find == 0)                          
          {
            return null;
          }
          var product = await _context.product
                                   .Where(p => p.enabled == true && p.IdProduct == producToBuy.IdProduct)
                                   .FirstAsync();

          if(producToBuy.Quantity > product.max || producToBuy.Quantity < product.min || producToBuy.Quantity > product.inInventory){
                return null;
          }
          }

          foreach(ProductList p in buy.ProductList){

          var find = await _context.product.Where(p => p.enabled == true && p.IdProduct == p.IdProduct).FirstAsync();

          find.inInventory = find.inInventory - p.Quantity;

          await _context.SaveChangesAsync();

          }

            _context.buy.Add(buy);
            await _context.SaveChangesAsync();
            return buy;

        }catch{
            return null;
        }
        }

        public async Task<Buy> UpdateBuy(Buy updatedbuy){
             return null;
        }

        public async Task<Buy> DeleteBuy(int id){
             return null;
        }

}
