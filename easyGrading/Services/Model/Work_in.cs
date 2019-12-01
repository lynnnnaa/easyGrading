using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services.Model
{
    public class Work_in
    {
        public int Id { get; set; }
        public int? Dep_Id { get; set; }

        public int? Prof_Id { get; set; }
    }
}
