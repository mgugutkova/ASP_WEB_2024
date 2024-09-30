using GameZone.Data;
using System.ComponentModel.DataAnnotations;
using static GameZone.Data.DataConstants;

namespace GameZone.Models
{
    public class GameFormViewModel
    {

        [Required]
        [StringLength(GameTitleMaxLength, MinimumLength = GameTitleMinLength, ErrorMessage = ErroMessageLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(GameDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        [Required]        
        public string ReleasedOn { get; set; } = string.Empty;

        [Required]
        public int GenreId { get; }

        public ICollection<Genres> Genres { get; set; } = new HashSet<Genres>();

    }
}
