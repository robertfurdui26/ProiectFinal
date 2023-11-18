using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]         
        public int Number {  get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }

        public int StudentId { get; set; }
    }
}
