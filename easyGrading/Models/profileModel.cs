using System;
using System.ComponentModel.DataAnnotations;

namespace easyGrading.Models
{
    public class ProfileModel
    {
        public string Username {get; set;}
        public string Degree {get; set;}
        public string Major {get; set;}
        public string Minor {get; set;}
    }
}
