using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicSystem.Models
{
    public class Rentals
    {
        [Key]
        public int RentalId { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        [Required]
        public DateTime RentailDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        public required string Status { get; set;}
    }
}