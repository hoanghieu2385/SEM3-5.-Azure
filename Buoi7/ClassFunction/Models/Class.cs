using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassFunction.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string ClassName { get; set; }
        public string RoomName { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}