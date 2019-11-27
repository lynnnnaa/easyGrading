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
    }
}
