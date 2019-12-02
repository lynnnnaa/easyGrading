using easyGrading.Models;
using easyGrading.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services.Interface
{
    public interface IDbQueries
    {
        public IEnumerable<Student> returnStudentInfoWithUserID(int userID);
        public IEnumerable<Professor> returnProfessorInfoWithUserID(int userID);
        public IEnumerable<Admin> returnAdminInfoWithUserID(int userID);
        public IEnumerable<Ta> returnTaInfoWithUserID(int userID);
        public IEnumerable<Department> returnAllDepartment();
        public bool isProf(int id);
        public void SaveStudent(Student model);

    }
}
