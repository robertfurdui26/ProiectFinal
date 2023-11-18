using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name{ get; set; }

        public int Age { get; set; }

        public double StudentTotalAverage { get; set; }

        public double CalculateTotalAverage()
        {
            if (Marks.Any())
            {
                return Marks.Average(n => n.Grade);
            }

            return 0; 
        }
        public Address Address { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();

        public List<Mark> Marks { get; set; } = new List<Mark>();


    }
}
