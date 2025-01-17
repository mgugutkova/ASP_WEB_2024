namespace PawnShop.Core.Models.Shop
{
    public class AllGoodsInShopViewModel
    {     
       
            public string Id { get; set; } = null!;
        
            public string AgreementId { get; set; } = null!;
        
            public string Name { get; set; } = null!;
            public string Description { get; set; } = null!;
        
            public decimal SellPrice { get; set; }
          
            public DateTime? SoldDate { get; set; }      
            public bool IsDeleted { get; set; } = false;

        }
    }


