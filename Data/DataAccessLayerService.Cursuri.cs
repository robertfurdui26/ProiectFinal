using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
