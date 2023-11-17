using System.ComponentModel.DataAnnotations;

namespace Proiect.Dtos
{
    public class MarkToCreateDto
    {
        [Range(1,10)]
        public int Grade { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public DateTime GradeTime { get; set; }


    }
}
