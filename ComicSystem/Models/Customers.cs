using System.ComponentModel.DataAnnotations;

namespace ComicSystem.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public required string Name { get; set; }

        [Required]
        public required string Phone { get; set; }

        public DateTime RegistrationDate { get; set;}
    }
}