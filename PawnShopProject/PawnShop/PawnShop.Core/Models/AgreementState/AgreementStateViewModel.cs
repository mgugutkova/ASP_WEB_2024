using System.ComponentModel.DataAnnotations;
using static PawnShop.Infrastructure.Data.DataConstants;

namespace PawnShop.Core.Models.AgreementState
{
    public class AgreementStateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
