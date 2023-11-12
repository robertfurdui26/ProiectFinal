using System.ComponentModel.DataAnnotations;

namespace Proiect.Dtos
{
    public class GetStudentMarkDto
    {
        [Range(0, int.MaxValue)]
        public int StudentId { get; set; }

        [Range(0, int.MaxValue)]
        public int CourseId { get; set; }

        [Range(1, 10)]
        public int Grade { get; set; }
    }
}
