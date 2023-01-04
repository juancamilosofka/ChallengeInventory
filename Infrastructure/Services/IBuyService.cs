using Microsoft.EntityFrameworkCore;
using Domain.Model;

namespace Infrastructure.Services;
public interface IBuyService
{
        public Task<List<Buy>> GetAllBuys();
        public Task<Buy> GetSingleBuy(int id);
public Task<List<Buy>> GetBuyByBuyerId(string id);
        public Task<Buy> AddBuy(Buy buy);

        public Task<Buy> UpdateBuy(Buy updatedbuy);

        public Task<Buy> DeleteBuy(int id);
}
