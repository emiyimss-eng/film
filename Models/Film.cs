using System.ComponentModel.DataAnnotations;

namespace FilmProjem.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required]
        public string Ad { get; set; } = string.Empty;

        public string? Tur { get; set; }

        public int Yil { get; set; }

        public string? Yonetmen { get; set; }

        public string? AfisUrl { get; set; }
    }
}