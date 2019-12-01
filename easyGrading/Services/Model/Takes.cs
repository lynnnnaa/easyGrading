using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services.Model
{
    public class Takes
    {
        public int Id { get; set; }
        public int Student_Id { get; set; }
        public string Course_Id { get; set; }
        public int? Goal { get; set; }
    }
}
