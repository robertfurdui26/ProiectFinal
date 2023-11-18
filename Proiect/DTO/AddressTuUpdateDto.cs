using System.ComponentModel.DataAnnotations;

namespace Proiect.Dtos
{
    /// <summary>
    /// Addres the will be used for update
    /// </summary>
    public class AddressTuUpdateDto
    {
        /// <summary>
        /// street number
        /// </summary>
        /// 
        [Required]
        public int Number { get; set; }
        /// <summary>
        /// city name
        /// </summary>
        /// 
        [Required]
        public string City { get; set; }
        /// <summary>
        /// street name
        /// </summary>
        /// 
        [Required]
        public string Street { get; set; }
    }
}
