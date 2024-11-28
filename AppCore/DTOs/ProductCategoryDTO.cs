using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.DTOs
{
    public class ProductCategoryDTO
    {
        [Key]
        [Range(1,5)]
        public int CategoryProductId { get; set; }

        [MaxLength(200)]
        public string CategoryDescription { get; set; }
    }
}
