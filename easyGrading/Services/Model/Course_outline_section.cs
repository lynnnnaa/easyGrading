using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services.Model
{
    public class Course_outline_section
    {
        public int Id { get; set; }
        public string Course_Id { get; set; }
        public int? Prof_Id { get; set; }
        public int percentage { get; set; }
        public string part { get; set; }

    }
}
