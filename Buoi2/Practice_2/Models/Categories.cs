using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_2.Models
{
    public class Categories
    {
        [Key]
        int CategoryId { get; set; }
        string CategoryName { get; set; }
    }
}