
using PawnShop.Core.Models.Agreement;
using PawnShop.Core.Models.Shop;

namespace PawnShop.Core.Interfaces
{
    public interface IShopService
    {
        Task<IEnumerable<AllGoodsInShopViewModel>> AllAsync();

        Task<IEnumerable<AllGoodsInShopViewModel>> AllNotSoldAsync();
        Task<EditGoodsInShop?> FindAsync(Guid? id);

        Task EditAsync(Guid id, EditGoodsInShop model);
        Task BuyAsync(Guid id);

        Task<AllGoodsInShopViewModel?> DeleteAsync(Guid? id);

        Task DeleteConfirmedAsync(Guid id);
    }
}
