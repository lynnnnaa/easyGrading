using System;
using System.ComponentModel.DataAnnotations;

namespace easyGrading.Models
{
    public class StudentViewModel
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int Id { get; set; }
        public int Major { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Minor { get; set; }
    }
}