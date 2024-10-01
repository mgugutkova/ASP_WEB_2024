using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
