using easyGrading.Models;
using easyGrading.Services.Interface;
using easyGrading.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services
{
    public class AccountServices: IAccountServices
    {
        private IDbQueries _dbQueries;
        public AccountServices(IDbQueries dbQueries) {
            _dbQueries = dbQueries;
            
        }
        public bool isUser(string userID, string password) {

            var query = from student in _dbQueries.returnStudentInfoWithUserID(userID)
                        where student.Id.ToString() == userID && student.Password == password
                        select student;

            var studentData = query.FirstOrDefault<Student>();

            return studentData != null;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return (_dbQueries.returnAllDepartment());
        }
    }
}
