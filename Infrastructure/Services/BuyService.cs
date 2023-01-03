using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Infrastructure.Data;

namespace Infrastructure.Services;
public class BuyService  : IBuyService
{
        private readonly DbContext _context;
        public BuyService(DbContext context)
        {
            _context = context;
        }
        public Task<List<Buy>> GetAllBuys(){
            return null;
        }
        public Task<Buy> GetSingleBuy(int id){
             return null;
        }

        public Task<List<Buy>> AddBuy(Buy buy){
             return null;
        }

        public Task<List<Buy>> UpdateBuy(Buy updatedbuy){
             return null;
        }

        public Task<Buy> DeleteBuy(int id){
             return null;
        }

}
