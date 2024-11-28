
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class ProductCategory
    {
        [Key]
        [Range(1,5)]
        public int CategoryProductId { get; set; }

        [MaxLength(200)]
        public string CategoryDescription { get; set; }

        public bool IsActive { get; set; }

    }
}
