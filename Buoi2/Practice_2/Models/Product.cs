using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_2.Models
{
    public class Product
    {
        [Key]
        int ProductId { get; set; }
        string ProductName { get; set; }
        double Price { get; set; }
    }
}