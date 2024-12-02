
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace PawnShop.Core.Models.Shop
{
    public class EditGoodsInShop
    {
        public int Id { get; set; }

        public int AgreementId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal SellPrice { get; set; }

      
        [DataType(DataType.Date)]
        public DateTime? SoldDate { get; set; }
    }
}
