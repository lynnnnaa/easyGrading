using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services.Model
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Admin_Id { get; set; }
    }
}
