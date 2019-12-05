using easyGrading.Models;
using easyGrading.Services.Interface;
using easyGrading.Services.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services
{
    public class DbQueries: IDbQueries
    {
        private EasyGradingContext _dbContext;
        public DbQueries(EasyGradingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Student> returnStudentInfoWithUserID(int userID) {
            
            var query = 
                $@"SELECT *
                    FROM dbo.student st
                    WHERE st.Id = {userID}";

            var student = _dbContext.Student
                .FromSqlRaw(query)
                .ToList();

            return student;
        }
        public IEnumerable<Professor> returnProfessorInfoWithUserID(int userID)
        {

            var query =
                $@"SELECT *
                    FROM dbo.professor p
                    WHERE p.Id = {userID}";

            var professor = _dbContext.Professor
                .FromSqlRaw(query)
                .ToList();

            return professor;
        }

        public IEnumerable<Admin> returnAdminInfoWithUserID(int userID)
        {

            var query =
                $@"SELECT *
                    FROM dbo.admin a
                    WHERE a.Id = {userID}";

            var admin = _dbContext.Admin
                .FromSqlRaw(query)
                .ToList();

            return admin;
        }

        public IEnumerable<Ta> returnTaInfoWithUserID(int userID)
        {

            var query =
                $@"SELECT *
                    FROM dbo.ta t
                    WHERE t.Id = {userID}";

            var Ta = _dbContext.Ta
                .FromSqlRaw(query)
                .ToList();

            return Ta;
        }
        public IEnumerable<Department> returnAllDepartment()
        {
            var query =
                $@"SELECT *
                    FROM dbo.department";

            var department = _dbContext.Department
                .FromSqlRaw(query)
                .ToList();

            return department;
        }

        public bool isProf(int id) 
        {
            var query =
                $@"SELECT *
                    FROM dbo.professor prof
                    WHERE prof.Id =id";

            var professor = _dbContext.Professor
                .FromSqlRaw(query)
                .ToList();
            return (professor != null);
        }

        public void SaveStudent(Student model) 
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }

        public Department GetDepartmentInfo(int id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.department d
                    WHERE d.Id={id}";

            var department = _dbContext.Department
                .FromSqlRaw(query)
                .ToList().FirstOrDefault<Department>();

            return department;
        }

        public IEnumerable<Takes> GetStudentCourses(int studentId)
        {
            var query =
                    $@"SELECT *
                    FROM dbo.takes t
                    WHERE t.Student_Id ={studentId}";

            var studentTakes = _dbContext.Takes
                .FromSqlRaw(query)
                .ToList();

            return studentTakes;
        }

        public Course GetCourseInfo(string courseId)
        {
            var query =
                        $@"SELECT *
                    FROM dbo.course c
                    WHERE c.Id = '{courseId}'";

            var course = _dbContext.Course
                .FromSqlRaw(query)
                .ToList().FirstOrDefault<Course>();

            return course;
        }

        public Professor GetProfessorInfo(int profId)
        {
            var query =
                        $@"SELECT *
                    FROM dbo.professor p
                    WHERE p.Id = {profId}";

            var professorInfo = _dbContext.Professor
                .FromSqlRaw(query)
                .ToList().FirstOrDefault<Professor>();

            return professorInfo;
        }
        public IEnumerable<Course> GetAllCourses() 
        {
            var query =
                $@"SELECT *
                FROM dbo.course";
            var courses = _dbContext.Course
                .FromSqlRaw(query)
                .ToList();

            return courses;
        }
        public void AddedClassToStudent(Takes model) 
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }

        public Ta GetTaInCourse(string courseId) 
        {
            var query =
                    $@"SELECT *
                FROM dbo.ta t
                WHERE t.Course_Id='{courseId}'";

            var taInfo = _dbContext.Ta
                .FromSqlRaw(query)
                .ToList().FirstOrDefault<Ta>();

            return taInfo;
        }

        public IEnumerable<Course_outline_section> GetCourse_Outline_Sections(string courseId)      
        {
            var query =
                    $@"SELECT *
                FROM dbo.course_outline_section c
                WHERE c.Course_Id='{courseId}'";

            var components = _dbContext.Course_Outline_Section
                .FromSqlRaw(query)
                .ToList();

            return components;
        }

        public Grade GetGrade(int courseOutlineId)
        {
            var query =
                        $@"SELECT *
                FROM dbo.grade g
                WHERE g.Course_Outline_Id={courseOutlineId}";

            var grade = _dbContext.Grade
                .FromSqlRaw(query)
                .ToList().FirstOrDefault<Grade>();

            return grade;
        }

        public IEnumerable<Grade> GetCourseGrade(string courseId) 
        {
            var query =
                           $@"SELECT *
                FROM dbo.grade g
                WHERE g.Course_Id='{courseId}'";

            var grade = _dbContext.Grade
                .FromSqlRaw(query)
                .ToList();

            return grade;
        }

        public Course_outline_section GetCourse_Outline(int courseOutlineId) 
        {
            var query =
                       $@"SELECT *
                FROM dbo.course_outline_section c
                WHERE c.Id={courseOutlineId}";

            var components = _dbContext.Course_Outline_Section
                .FromSqlRaw(query)
                .ToList().FirstOrDefault<Course_outline_section>();

            return components;
        }
    }
}
