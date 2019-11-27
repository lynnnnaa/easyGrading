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
        public IEnumerable<Student> returnStudentInfoWithUserID(string userID);
        public IEnumerable<Department> returnAllDepartment();

        public void SaveStudent(Student model);

    }
}
