using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Models
{
    public class Course_Outline_Section
    {
        public int Id { get; set; }
        public int Percentage { get; set; }
        public int Prof_Id{ get; set; }
        public string Course_Id { get; set; }
        public string Part { get; set; }

    }
}
