using StudentsShadowing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsShadowing.Models.ViewModels
{
    public class EditProfessionalVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public Professional GetEditProfessionalInstance()
        {
            return new Professional
            {
                Id = Id,
                Name = Name,
                Category = Category
            };
        }
    }
}
