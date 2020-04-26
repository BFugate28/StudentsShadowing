using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsShadowing.Models.Entities
{
    public class Professional
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
