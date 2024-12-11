using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Shop;
using PawnShop.Infrastructure.Data.Model;
using PawnShop.Infrastructure.Data.Repo;

namespace PawnShop.Core.Services
{
    public class ShopService : IShopService
    {

        private readonly IRepository repository;
        private readonly ILogger logger;
        public ShopService(
            IRepository _repository,
            ILogger<ShopService> _logger)
        {
            repository = _repository;   
            logger = _logger;
        }

        public async Task<IEnumerable<AllGoodsInShopViewModel>> AllAsync()
        {
            var goods = await repository.AllReadOnly<Shop>()
                .Where(s => s.IsDeleted == false)
                .Select(x => new AllGoodsInShopViewModel()
                {
                    Id = x.Id,
                    SellPrice = x.SellPrice,
                    SoldDate = x.SoldDate,
                    Name = x.Name,
                    Description = x.Description ?? string.Empty
                })
                .ToListAsync();

            return goods;
        }

        public async Task<IEnumerable<AllGoodsInShopViewModel>> AllNotSoldAsync()
        {
            var goods = await repository.AllReadOnly<Shop>()
                .Where(s => s.IsDeleted == false)
                .Where(g => g.SoldDate == null)
                .Select(x => new AllGoodsInShopViewModel()
                {
                    Id = x.Id,
                    SellPrice = x.SellPrice,
                    SoldDate = x.SoldDate,
                    Name = x.Name,
                    Description = x.Description ?? string.Empty
                })
                .ToListAsync();

            return goods;
        }

        public async Task BuyAsync(int id)
        {
            var goods = await repository.All<Shop>()
             .Where(x => x.Id == id)
             .Where(x => x.IsDeleted == false)
             .Where(x => x.SoldDate == null)
             .FirstOrDefaultAsync();

            if (goods != null)
            {
                goods.SoldDate = DateTime.UtcNow;             

                await repository.SaveChangesAsync();
            }
        }

        public async Task<AllGoodsInShopViewModel?> DeleteAsync(int? id)
        {
            var goods = await repository.AllReadOnly<Shop>()
             .Where(a => a.Id == id)
             .Where(a => a.IsDeleted == false)
             .Select(s => new AllGoodsInShopViewModel()
             {
                 Id = s.Id,
                 Name = s.Name,
                 Description = s.Description ?? string.Empty,
                 SellPrice = s.SellPrice,
                 SoldDate = s.SoldDate,
             })
             .FirstOrDefaultAsync();

            return goods;
        }

        public async Task DeleteConfirmedAsync(int id)
        {
            var goods = await repository.All<Shop>()
                 .Where(x => x.Id == id)
                 .Where(x => x.IsDeleted == false)
                 .FirstOrDefaultAsync();

            if (goods != null)
            {
                goods.IsDeleted = true;

                await repository.SaveChangesAsync();
            }
        }

        public async Task EditAsync(int id, EditGoodsInShop model)
        {
            var goods = await repository.All<Shop>()
                 .Where(x => x.Id == id)
                 .Where(x => x.IsDeleted == false)
                 .FirstOrDefaultAsync();

            if (goods != null)
            {
                goods.SellPrice = model.SellPrice;
                goods.SoldDate = model.SoldDate;
                goods.Name = model.Name;
                goods.Description = model.Description;  

                await repository.SaveChangesAsync();
            }
        }

        public async Task<EditGoodsInShop?> FindAsync(int? id)
        {
            var goods = await repository.All<Shop>()
                .Where(x => x.Id == id)
                .Where(x => x.IsDeleted == false)
                .Select(s => new EditGoodsInShop()
                {
                    Id = s.Id,                   
                    Name = s.Name,
                    Description = s.Description ?? string.Empty,
                    SellPrice = s.SellPrice,
                    SoldDate = s.SoldDate
                })
                .FirstOrDefaultAsync();

            return goods;
        }
    }
}
