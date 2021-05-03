using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderManagementSystem_WebAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Name Required")]
        [MaxLength(50, ErrorMessage = "The max length of the Product Name field is 50 characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Supplier Id Required")]
        public int SupplierId { get; set; }

        public decimal? UnitPrice { get; set; }

        [MaxLength(30, ErrorMessage = "The max length of the Package field is 30 characters")]
        public string Package { get; set; }

        public bool? IsDiscontinued { get; set; }

        public Supplier Suppliers { get; set; }
    }
}