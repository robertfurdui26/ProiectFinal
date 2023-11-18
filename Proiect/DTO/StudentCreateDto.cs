using System.ComponentModel.DataAnnotations;

namespace Proiect.Dtos
{
    public class StudentCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
