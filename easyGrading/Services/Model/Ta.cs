﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Models
{
    public class Ta
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Prof_Id { get; set; }
        public string Course_Id { get; set; }
    }
}
