using StudentsShadowing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsShadowing.Models.ViewModels
{
    public class CreateStudentVm
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Interest { get; set; }

        public Student GetStudentInstance()
        {
            return new Student
            {
                Id = 0,
                Name = Name,
                Age = Age,
                Interest = Interest

            };
        }
    }
}
