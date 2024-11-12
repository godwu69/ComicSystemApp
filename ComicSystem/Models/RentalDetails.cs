using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicSystem.Models
{
    public class RentalDetails
    {
        [Key]
        public int RentalDetailId { get; set; }

        [ForeignKey("RentalId")]
        public int RentalId { get; set; }

        [ForeignKey("ComicBookId")]
        public int ComicBookId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal PricePerDay { get; set;}
    }
}