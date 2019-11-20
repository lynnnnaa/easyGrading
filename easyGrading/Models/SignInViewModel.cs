using System;
using System.ComponentModel.DataAnnotations;

namespace easyGrading.Models
{
    public class SignInViewModel
    {
        public string UserID { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Error { get; set; }
    }
}