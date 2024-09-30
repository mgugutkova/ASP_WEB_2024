using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameZone.Data.DataConstants;

namespace GameZone.Data
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GameTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(GameDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        public string PublisherId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(PublisherId))]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        public DateTime ReleasedOn { get; set;}

        [Required]
        public int GenreId { get; set; }

        [Required]
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public ICollection<GamerGame> GamersGames { get; set; } = new HashSet<GamerGame>();
    }
}
