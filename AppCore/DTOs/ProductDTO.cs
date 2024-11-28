
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace AppCore.DTOs
{
    public class ProductDTO
    {
        [Key]
        [MaxLength(30)]
        [Required]
        public string ProductId { get; set; }

        [Range(1, 5)]
        [Required]
        public int CategoryProductId { get; set; }

        [MaxLength(200)]
      
        public string CategoryDescription { get; set; }

        [MaxLength(200)]
        [Required]
        public string ProductDescription { get; set; }

        [Range(1,5)]
        public int Stock { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        [Required]
        public decimal Price { get; set; }

        public bool HaveECDiscount { get; set; }

        public bool IsActive { get; set; }


    }
}
