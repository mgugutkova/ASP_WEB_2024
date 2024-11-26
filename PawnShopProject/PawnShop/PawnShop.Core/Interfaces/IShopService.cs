
using PawnShop.Core.Models.Agreement;
using PawnShop.Core.Models.Shop;

namespace PawnShop.Core.Interfaces
{
    public interface IShopService
    {
        Task<IEnumerable<AllGoodsInShopViewModel>> AllAsync();

        Task<EditGoodsInShop?> FindAsync(int? id);

        Task EditAsync(int id, EditGoodsInShop model);

        Task<AllGoodsInShopViewModel?> DeleteAsync(int? id);

        Task DeleteConfirmedAsync(int id);
    }
}
