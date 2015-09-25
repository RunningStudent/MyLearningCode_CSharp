using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentModel
{
    public class Student
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int? MathScore { get; set; }
        public int EnglishScore { get; set; }
        public StudentClass Myclass{ get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public int StudentId { get; set; }
    }
}
