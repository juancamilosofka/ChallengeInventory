using Microsoft.EntityFrameworkCore;
using Domain.Model;

namespace Infrastructure.Services;
public interface IBuyService
{
        public Task<List<Buy>> GetAllBuys();
        public Task<Buy> GetSingleBuy(int id);

        public Task<List<Buy>> AddBuy(Buy buy);

        public Task<List<Buy>> UpdateBuy(Buy updatedbuy);

        public Task<Buy> DeleteBuy(int id);
}
