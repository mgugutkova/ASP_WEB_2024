using System.ComponentModel.DataAnnotations;
using static GameZone.Data.DataConstants;
namespace GameZone.Data
{
    public class Genre
    {
        [Key]
        public  int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Game> Games { get; set; } = new HashSet<Game>();
    }
}