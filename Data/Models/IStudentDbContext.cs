using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public interface IStudentDbContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Student> Students { get; set; }
   }
}