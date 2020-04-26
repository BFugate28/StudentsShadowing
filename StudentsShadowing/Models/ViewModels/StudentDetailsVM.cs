using StudentsShadowing.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsShadowing.Models.ViewModels
{
    public class StudentDetailsVM
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Age")]
        public int Age { get; set; }
        [DisplayName("Interest")]
        public string Interest { get; set; }

        public ICollection<Professional> Professionals { get; set; }
    }
}
