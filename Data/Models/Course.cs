﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public  class Course
    {
        public int Id { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Mark> Marks { get; set; } = new List<Mark>();
        public string Name { get; set; }

    }
}
