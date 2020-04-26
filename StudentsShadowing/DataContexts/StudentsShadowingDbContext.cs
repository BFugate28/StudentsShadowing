using Microsoft.EntityFrameworkCore;
using StudentsShadowing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsShadowing.DataContexts
{
    public class StudentsShadowingDbContext :DbContext
    {
        public StudentsShadowingDbContext(DbContextOptions options) :base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professional> Professionals { get; set; }
    }
}
