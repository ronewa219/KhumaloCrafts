using System.ComponentModel.DataAnnotations;

namespace KhumaloCrafts.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public required string Description { get; set; }  // Use the 'required' modifier

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }
        public string? imageURL { get; set; } // This property will store the URL of the product image.
        public object? ImageUrl { get; internal set; }
    }
}
