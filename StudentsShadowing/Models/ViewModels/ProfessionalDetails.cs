using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsShadowing.Models.ViewModels
{
    public class ProfessionalDetails
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Category")]
        public string Category { get; set; }

    }
}
