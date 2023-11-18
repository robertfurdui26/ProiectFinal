using System.ComponentModel.DataAnnotations;

namespace Proiect.Dtos
{
    public class MarkToCreateDto
    {
        [Range(1,10)]
        public int Grade { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int StudentId { get; set; }
        [Required]
        public DateTime GradeTime { get; set; }


    }
}
