using Microsoft.EntityFrameworkCore;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Shop;
using PawnShop.Infrastructure.Data.Model;
using PawnShop.Infrastructure.Data.Repo;

namespace PawnShop.Core.Services
{
    public class ShopService : IShopService
    {

        private readonly IRepository repository;
       
        public ShopService(IRepository _repository)
        {
            repository = _repository;           
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
            var item = await repository.All<Shop>()
             .Where(x => x.Id == id)
             .Where(x => x.IsDeleted == false)
             .Where(x => x.SoldDate == null)
             .FirstOrDefaultAsync();

            if (item != null)
            {
                item.SoldDate = DateTime.UtcNow;             

                await repository.SaveChangesAsync();
            }
        }

        public async Task<AllGoodsInShopViewModel?> DeleteAsync(int? id)
        {
            var model = await repository.AllReadOnly<Shop>()
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

            return model;
        }

        public async Task DeleteConfirmedAsync(int id)
        {
            var item = await repository.All<Shop>()
                 .Where(x => x.Id == id)
                 .Where(x => x.IsDeleted == false)
                 .FirstOrDefaultAsync();

            if (item != null)
            {
                item.IsDeleted = true;

                await repository.SaveChangesAsync();
            }
        }

        public async Task EditAsync(int id, EditGoodsInShop model)
        {
            var item = await repository.All<Shop>()
                 .Where(x => x.Id == id)
                 .Where(x => x.IsDeleted == false)
                 .FirstOrDefaultAsync();

            if (item != null)
            {
                item.SellPrice = model.SellPrice;
                item.SoldDate = model.SoldDate;
                item.Name = model.Name;
                item.Description = model.Description;  

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
