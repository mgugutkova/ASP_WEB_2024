namespace PawnShop.Core.Models.Shop
{
    public class AllGoodsInShopViewModel
    {     
       
            public int Id { get; set; }
        
            public int AgreementId { get; set; }
        
            public string GoodsName { get; set; } = null!;
        
            public decimal SellPrice { get; set; }
          
            public DateTime? SoldDate { get; set; }      
            public bool IsDeleted { get; set; } = false;

        }
    }


