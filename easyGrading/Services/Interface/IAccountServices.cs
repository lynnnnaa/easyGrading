using easyGrading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services.Interface
{
    public interface IAccountServices
    {
        public bool isUserStudent(int userID, string password);
        public bool isUserProfessor(int userID, string password);
        public bool isUserAdmin(int userID, string password);
        public bool isUserTa(int userID, string password);
        public IEnumerable<Department> GetDepartments();
        public ProfileModel GetProfile(int userId);
    }
}
