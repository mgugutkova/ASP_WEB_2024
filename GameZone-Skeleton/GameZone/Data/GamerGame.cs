using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Data
{
    public class GamerGame
    {
        [Key]
        public  int GameId { get; set; }

        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        [Key] 
        public string GamerId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(GamerId))]
        public IdentityUser Gamer { get; set; } = null!;
    }
}