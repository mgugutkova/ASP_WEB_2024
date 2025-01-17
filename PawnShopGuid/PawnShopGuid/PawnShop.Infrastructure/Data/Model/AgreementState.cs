using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PawnShop.Infrastructure.Data.DataConstants;

namespace PawnShop.Infrastructure.Data.Model
{
	public class AgreementState
	{
		[Key]
        [Comment("Идентификатор на статус")]
        public int Id { get; set; }

        [Required]
        [MaxLength(StateNameMaxLength)]
        [Comment("Име на статуса")]
        public string Name { get; set; } = string.Empty;
    }
}