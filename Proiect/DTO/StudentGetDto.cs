using System.ComponentModel.DataAnnotations;

namespace Proiect.Dto
{
    public class StudentGetDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
