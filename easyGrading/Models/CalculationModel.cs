using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Models
{
    public class CalculationModel
    {
        public string CourseName { get; set; }
        public string CurrentGrade { get; set; }
        public string TargetGrade { get; set; }
        public string Components { get; set; }
        public string Marks { get; set; }
        public string Status { get; set; }
    }
}
