using System.ComponentModel.DataAnnotations;

namespace Proiect.Dtos
{
    public class OrderStudentDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }

        public double AverageTotal { get; set; }

    }
}
