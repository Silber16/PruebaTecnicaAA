
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        [MaxLength(30)]
        public string ProductId { get; set; }

        [MaxLength(5)]
        public int CategoryProductId { get; set; }

        [MaxLength(200)]
        public string ProductDescription { get; set; }

        [MaxLength(5)]
        public int Stock { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public int Price { get; set; }

        public bool HAveECDiscount { get; set; }

        public bool IsActive {get;set;}


        public ProductCategory? CategoryProduct { get; set; }

    }
}
