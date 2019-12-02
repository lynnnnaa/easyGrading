using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services.Model
{
    public class Course
    {
        public string Id { get; set; }
        public int? Dep_Id { get; set; }
        public int? Prof_Id { get; set; }
        public int? Prof_Id2{ get; set; }
        public string Name { get; set; }
    }
}
