using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.DTOs
{
    public class CreateProductDTO
    {
        [Key]
        [MaxLength(30)]
        [Required]
        public string ProductId { get; set; }

        [Range(1,5)]
        [Required]
        public int CategoryProductId { get; set; }

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
