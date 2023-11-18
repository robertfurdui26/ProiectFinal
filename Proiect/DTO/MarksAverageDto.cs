using System.ComponentModel.DataAnnotations;

namespace Proiect.Dtos
{
    public class MarksAverageDto
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int StudentId { get; set; }

        public double AverageTotal { get; set; }

    }
}
