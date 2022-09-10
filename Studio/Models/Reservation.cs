using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Studio.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public String Name { get; set; }
        public String Service { get; set; }
        [Required]
        public String Phone { get; set; }
    }
}
