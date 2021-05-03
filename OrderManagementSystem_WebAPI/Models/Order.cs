using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrderManagementSystem_WebAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Order Date Required")]
        public DateTime OrderDate { get; set; }

        [MaxLength(10, ErrorMessage = "The max length of the Order Number field is 10 characters")]
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "Customer Id Required")]
        public int CustomerId { get; set; }

        public double? TotalAmount { get; set; }

        public Customer Customers { get; set; }
    }
}