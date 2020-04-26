using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsShadowing.Models.ViewModels
{
    public class StudentsListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Interest { get; set; }
    }
}
