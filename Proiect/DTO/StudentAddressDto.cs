using System.ComponentModel.DataAnnotations;

namespace Proiect.Dtos
{
    public class StudentAddressDto
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
    }
}
