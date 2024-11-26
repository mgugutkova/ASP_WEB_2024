
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawnShop.Core.Models.Shop
{
    public class EditGoodsInShop
    {
        public int Id { get; set; }

        public int AgreementId { get; set; }

        public string GoodsName { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal SellPrice { get; set; } 
        
        public DateTime? SoldDate { get; set; }
    }
}
