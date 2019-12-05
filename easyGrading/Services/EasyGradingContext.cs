using easyGrading.Models;
using easyGrading.Services.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services
{
    public class EasyGradingContext: DbContext
    {
        public EasyGradingContext(DbContextOptions<EasyGradingContext> options) : base(options) { }
        
        public DbSet<Student> Student { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Ta> Ta { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Work_in> Work_in { get; set; }
        public DbSet<Takes> Takes { get; set; }
        public DbSet<Course_outline_section> Course_Outline_Section { get; set; }
        public DbSet<Grade> Grade { get; set; }

    }
}
