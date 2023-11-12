using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Mark
    {
        
        public int Id { get; set; }
        public int Grade { get; set; }

        public DateTime GradeTime { get; set; }

        public Course Courses { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }


        public double AverageTotal { get; set; }
    }
}
