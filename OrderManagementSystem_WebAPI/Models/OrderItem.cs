using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrderManagementSystem_WebAPI.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Order Id Required")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Product Id Required")]
        public int ProductId { get; set; } 

        [Required(ErrorMessage = "Unit Price Required")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Quantity Required")]
        public int Quantity { get; set; }

        public Order Orders { get; set; }

        public Product Products { get; set; }
    }
}