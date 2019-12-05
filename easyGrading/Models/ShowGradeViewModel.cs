using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Models
{
    public class ShowGradeViewModel
    {
        public int Id { get; set; }
        public int Student_Id { get; set; }
        public string Course_Id { get; set; }
        public int? Actual_Grade { get; set; }
        public int Course_Outline_Id { get; set; }
        public string Course_Outline_Part { get; set; }
        public bool Editable { get; set; }
        public int Percentage{ get; set; }
    }
}
