using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace APM.WebAPI.Models
{
    public class Product
    {
        public string Description { get; set; }
        public decimal Price { get; set; }

        [Required(ErrorMessage = "product code is required", AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = "min length is 6")]
        public string ProductCode { get; set; }

        public int ProductId { get; set; }
        
        [Required(ErrorMessage="Requerido", AllowEmptyStrings = false)]
        [MinLength(4, ErrorMessage = "Product Name min req")]
        [MaxLength(12, ErrorMessage = "Product name max!")]
        public string ProductName { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}