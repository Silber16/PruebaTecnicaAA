
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        [MaxLength(30)]
        [Required(ErrorMessage = "Id is required.")]
        public string ProductId { get; set; }

        [Range(1,5)]
        [Required(ErrorMessage = "category is required.")]
        public int CategoryProductId { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "Description is required.")]
        public string ProductDescription { get; set; }

        [Range(1,5)]
        public int Stock { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        public bool HaveECDiscount { get; set; }

        public bool IsActive {get;set;}


        public ProductCategory? CategoryProduct { get; set; }

    }
}
