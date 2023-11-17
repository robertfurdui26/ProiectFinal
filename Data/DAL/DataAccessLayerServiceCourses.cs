using Data.Models;
namespace Data
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public Course AddCourse(string nameCourse)
        {
            var curs = new Course { Name =  nameCourse };
            ctx.Coursess.Add(curs);
            ctx.SaveChanges();
            return curs;
        }

        public List<Course> GetAllCursuri() => ctx.Coursess.ToList();
    }
}
