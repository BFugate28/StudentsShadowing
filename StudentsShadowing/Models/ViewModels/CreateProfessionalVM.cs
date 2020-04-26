using StudentsShadowing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsShadowing.Models.ViewModels
{
    public class CreateProfessionalVM
    {
        public string Name { get; set; }
        public string Category { get; set; }

        public Professional GetProfessionalInstance()
        {
            return new Professional
            {
                Id = 0,
                Name = Name,
                Category = Category
            };
        }
    }
}
