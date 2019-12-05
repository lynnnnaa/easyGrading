using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services.Model
{
    public class Grade
    {
        public int Student_Id { get; set; }
        public string Course_Id { get; set; }
        public int Course_Outline_Id { get; set; }
        public int? Actual_Grade { get; set; }
        public int? Expected_Grade { get; set; }
        public bool Editable { get; set; } 
        public int Id { get; set; }
    }
}
