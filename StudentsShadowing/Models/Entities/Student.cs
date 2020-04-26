using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsShadowing.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Interest { get; set; }

        public ICollection<Professional> Professionals { get; set; }

        public Student()
        {
            Professionals = new List<Professional>();
        }
    }
}
