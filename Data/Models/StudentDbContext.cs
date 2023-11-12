using Microsoft.EntityFrameworkCore;


namespace Data.Models
{
    public class StudentDbContext : DbContext, IStudentDbContext
    {


        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Course> Coursess { get; set; }

        public DbSet<Mark> Marks {  get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
