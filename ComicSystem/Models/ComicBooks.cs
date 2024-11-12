using System.ComponentModel.DataAnnotations;

namespace ComicSystem.Models
{
    public class ComicBooks
    {
        [Key]
        public int ComicBookId { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Author { get; set; }

        [Required]
        public decimal PricePerDay { get; set;}
    }
}