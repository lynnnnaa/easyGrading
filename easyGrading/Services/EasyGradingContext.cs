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
        
        public DbSet<Student> Students { get; set; }
    }
}
