using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassFunction.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(18,30,ErrorMessage ="Only accept from 18 to 30 year old")]
        public int Age { get; set; }
        [MaxLength(200,ErrorMessage ="Can not greater than 200 characters")]
        public string Address { get; set; }
        [ForeignKey("ClassId")]
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}