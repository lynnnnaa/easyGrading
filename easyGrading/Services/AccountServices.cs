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

        public bool isUserStudent(int userID, string password) 
        {
            var query = from student in _dbQueries.returnStudentInfoWithUserID(userID)
                        where student.Id == userID && student.Password == password
                        select student;

            var studentData = query.FirstOrDefault<Student>();

            return studentData != null;
        }

        public bool isUserProfessor(int userID, string password)
        {
            var query = from professor in _dbQueries.returnProfessorInfoWithUserID(userID)
                        where professor.Id == userID && professor.Password == password
                        select professor;

            var professorData = query.FirstOrDefault<Professor>();

            return professorData != null;
        }

        public bool isUserAdmin(int userID, string password)
        {
            var query = from admin in _dbQueries.returnAdminInfoWithUserID(userID)
                        where admin.Id == userID && admin.Password == password
                        select admin;

            var adminData = query.FirstOrDefault<Admin>();

            return adminData != null;
        }

        public bool isUserTa(int userID, string password)
        {
            var query = from Ta in _dbQueries.returnTaInfoWithUserID(userID)
                        where Ta.Id == userID && Ta.Password == password
                        select Ta;

            var TaData = query.FirstOrDefault<Ta>();

            return TaData != null;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return (_dbQueries.returnAllDepartment());
        }
    }
}
