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
        #region Student
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

        public void SaveStudent(Student model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }

        public void ReSignStudentMajor(int id)
        {
            var query =
                $@"UPDATE dbo.student
                    SET Major=0
                    WHERE Major = {id}";
            try
            {
                var st = _dbContext.Student
                    .FromSqlRaw(query)
                    .ToList();
            }
            catch { }

            var query2 =
                $@"UPDATE dbo.student
                    SET Minor=0
                    WHERE Minor = {id}";
            try
            {
                var st = _dbContext.Student
                    .FromSqlRaw(query2)
                    .ToList();
            }
            catch { }
        }

        public bool isStudent(int id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.student s
                    WHERE s.Id = {id}";

            var std = _dbContext.Student
                .FromSqlRaw(query)
                .ToList();
            return (std.Count() != 0);
        }

        #endregion

        #region Professor
        public bool isProf(int id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.professor prof
                    WHERE prof.Id = {id}";

            var professor = _dbContext.Professor
                .FromSqlRaw(query)
                .ToList();
            return (professor.Count() != 0);
        }

        public bool isProf(int id, string password)
        {
            var query =
                $@"SELECT *
                    FROM dbo.professor prof
                    WHERE prof.Id = {id} AND prof.Password='{password}'";

            var professor = _dbContext.Professor
                .FromSqlRaw(query)
                .ToList();
            return (professor.Count() != 0);
        }

        public IEnumerable<Professor> returnAllProfessor()
        {
            var query =
               $@"SELECT *
                    FROM dbo.professor";

            var professor = _dbContext.Professor
                .FromSqlRaw(query)
                .ToList();

            return professor;
        }

        public IEnumerable<Professor> returnAllProfessor2()
        {
            var query =
               $@"SELECT *
                    FROM dbo.professor p
                    WHERE p.Id !=0";

            var professor = _dbContext.Professor
                .FromSqlRaw(query)
                .ToList();

            return professor;
        }

        public Professor GetProf(int id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.professor p
                    WHERE p.Id = {id}";

            var prof = _dbContext.Professor
                .FromSqlRaw(query)
                .ToList();

            return prof[0];
        }

        public void ProfessorUpdate(Professor model)
        {
            var query =
                $@"UPDATE dbo.professor 
                    SET Name='{model.Name}', Password='{model.Password}'
                    WHERE Id = {model.Id}";
            try
            {
                var prof = _dbContext.Professor
                    .FromSqlRaw(query)
                    .ToList();

            }
            catch { }

        }

        public void ProfessorDelete(Professor model)
        {
            _dbContext.Remove(model);
            _dbContext.SaveChanges();
        }
        public void SaveProfessor(Professor model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }
        #endregion

        #region Department
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

        public Department returnDepartName(int id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.department dp
                    WHERE dp.Id = {id}";

            var depart = _dbContext.Department
                .FromSqlRaw(query)
                .ToList();

            return depart[0];
        }

        public bool checkDepartmentName(string name)
        {
            var query =
                $@"SELECT *
                    FROM dbo.department d
                    WHERE d.Name ='{name}'";

            var de = _dbContext.Department
                .FromSqlRaw(query)
                .ToList();

            return (de.Count() != 0);
        }
        public bool CheckDepartmentId(int id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.department d
                    WHERE d.Id = {id}";

            var de = _dbContext.Department
                .FromSqlRaw(query)
                .ToList();
            return (de.Count() != 0);
        }
        public void SaveDepartment(Department model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }

        public void DepartmentUpdate(Department model)
        {
            var query =
                $@"UPDATE dbo.department
                    SET Name='{model.Name}'
                    WHERE Id = {model.Id}";
            try
            {
                var departments = _dbContext.Department
                    .FromSqlRaw(query)
                    .ToList();
            }
            catch { }
        }

        public void DepartmentDelete(Department model)
        {
            _dbContext.Remove(model);
            _dbContext.SaveChanges();
        }
        #endregion



        #region Course

        public IEnumerable<Course> returnAllCourse(int id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.course course
                    WHERE course.Dep_Id = {id}";

            var course = _dbContext.Course
                .FromSqlRaw(query)
                .ToList();

            return course;
        }

        public bool checkCourseName(string name)
        {
            var query =
                $@"SELECT *
                    FROM dbo.course c
                    WHERE c.Name ='{name}'";

            var course = _dbContext.Course
                .FromSqlRaw(query)
                .ToList();

            return (course.Count() != 0);
        }

        public bool CheckCourseId(string id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.course c
                    WHERE c.Id = '{id}'";

            var course = _dbContext.Course
                .FromSqlRaw(query)
                .ToList();
            return (course.Count() != 0);
        }
        public void SaveCourse(Course model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }

        public Course GetCourse(string id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.course c
                    WHERE c.Id = '{id}'";

            var course = _dbContext.Course
                .FromSqlRaw(query)
                .ToList();

            return course[0];
        }

        public void ReSignCourseDepartment(int id)
        {
            var query =
                $@"UPDATE dbo.course
                    SET Dep_Id=0
                    WHERE Dep_Id = {id}";
            try
            {
                var course = _dbContext.Course
                    .FromSqlRaw(query)
                    .ToList();
            }
            catch { }
        }

        public void CourseUpdate(Course model)
        {
            var query =
                $@"UPDATE dbo.course
                    SET Dep_Id={model.Dep_Id}, Name='{model.Name}', Prof_Id='{model.Prof_Id}', Prof_Id2='{model.Prof_Id2}'
                    WHERE Id = '{model.Id}'";
            try
           {
                var course = _dbContext.Course
                    .FromSqlRaw(query)
                    .ToList();
            }
           catch { }
        }

        public void ReSignCourseProf(int id)
        {
            var query =
                $@"UPDATE dbo.course
                    SET Prof_Id=0
                    WHERE Prof_Id = {id}";
            try
            {
                var course = _dbContext.Course
                    .FromSqlRaw(query)
                    .ToList();
            }
            catch { }

            var query2 =
                $@"UPDATE dbo.course
                    SET Prof_Id2=0
                    WHERE Prof_Id2 = {id}";
            try
            {
                var course = _dbContext.Course
                    .FromSqlRaw(query2)
                    .ToList();
            }
            catch { }
        }

        public void CourseDelete(Course model)
        {
            _dbContext.Remove(model);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Course> returnAllProfessorCourse(int id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.course course
                    WHERE course.Prof_Id = {id} OR course.Prof_Id2 = {id}";

            var course = _dbContext.Course
                .FromSqlRaw(query)
                .ToList();

            return course;
        }

        #endregion

        #region Admin
        public bool isAdmin(int id, string password)
        {
            var query =
                $@"SELECT *
                    FROM dbo.admin admin
                    WHERE admin.Id = {id} AND admin.Password='{password}'";

            var admin = _dbContext.Admin
                .FromSqlRaw(query)
                .ToList();
            return (admin.Count() != 0);
        }
        public Admin GetAdmin(int id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.admin a
                    WHERE a.Id = {id}";

            var admin = _dbContext.Admin
                .FromSqlRaw(query)
                .ToList();

            return admin[0];
        }
        public void AdminUpdate(Admin model)
        {
            var query =
                $@"UPDATE dbo.admin 
                    SET Name='{model.Name}', Password='{model.Password}'
                    WHERE Id = {model.Id}";
            try
            {
                var admin = _dbContext.Admin
                    .FromSqlRaw(query)
                    .ToList();
            }
            catch { }
        }

        public bool isAdmin(int id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.admin a
                    WHERE a.Id = {id}";

            var admin = _dbContext.Admin
                .FromSqlRaw(query)
                .ToList();
            return (admin.Count() != 0);
        }

        #endregion


        #region Work_In
        public void SaveWorkin(Work_in model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }

        public bool CheckWorkIn(int prof_id, int Dep_Id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.work_in w
                    WHERE w.Prof_Id ={prof_id} AND w.Dep_Id ={Dep_Id}";

            var WORK = _dbContext.Work_in
                .FromSqlRaw(query)
                .ToList();

            return (WORK.Count() != 0);
        }

        public IEnumerable<Work_in> returnAllWorkIn(int id)
        {
            var query =
               $@"SELECT *
                    FROM dbo.work_in w
                    WHERE w.Prof_Id={id}";

            var work = _dbContext.Work_in
                .FromSqlRaw(query)
                .ToList();

            return work;
        }

        public void WorkInDelete(int id, string column)
        {
           var query = $@"";
            if (column == "prof") {
                query =
                    $@"SELECT *
                    FROM dbo.work_in w
                    WHERE w.Prof_Id = {id}";
            }
            else {
                query =
              $@"SELECT *
                    FROM dbo.work_in w
                    WHERE w.Dep_Id = {id}";
            }
            

            var work = _dbContext.Work_in
                .FromSqlRaw(query)
                .ToList();

            for(int i=0; i<work.Count(); i++) 
            {
                _dbContext.Remove(work[i]);
            }
            
            _dbContext.SaveChanges();
        }

        public void WorkInDelete2(int Profid, int Depid)
        {
            var query =
                    $@"SELECT *
                    FROM dbo.work_in w
                    WHERE w.Prof_Id = {Profid} AND w.Dep_Id = {Depid}";

            var work = _dbContext.Work_in
                .FromSqlRaw(query)
                .ToList();

            _dbContext.Remove(work[0]);
            _dbContext.SaveChanges();
        }

        public Work_in GetWorkIn(int Prof_Id, int Dep_Id)
        {
            var query =
               $@"SELECT *
                    FROM dbo.work_in w
                    WHERE w.Prof_Id = {Prof_Id} AND w.Dep_Id = {Dep_Id}";

            var work = _dbContext.Work_in
                .FromSqlRaw(query)
                .ToList();

            return work[0];
        }

        public void WorkInUpdate(int Prof_Id, int Old, int Dep_Id)
        {
            var query =
                $@"UPDATE dbo.work_in
                    SET Dep_Id={Dep_Id}
                    WHERE Dep_Id={Old} AND Prof_Id={Prof_Id}";
            try
            {
                var WORK = _dbContext.Work_in
                    .FromSqlRaw(query)
                    .ToList();
            }
            catch { }
        }

        #endregion

        #region Ta
        public void ReSignTa(string id)
        {
            var query =
                $@"UPDATE dbo.ta
                    SET Course_Id=null
                    WHERE Course_Id = '{id}'";
            try
            {
                var ta = _dbContext.Ta
                    .FromSqlRaw(query)
                    .ToList();
            }
            catch { }
        }

        public void ReSignTaProf_Id(int id)
        {
            var query =
                $@"UPDATE dbo.ta
                    SET Prof_Id=0
                    WHERE Prof_Id={id}";
            try
            {
                var ta = _dbContext.Ta
                    .FromSqlRaw(query)
                    .ToList();
            }
            catch { }
        }

        public bool isTa(int id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.ta t
                    WHERE t.Id = {id}";

            var ta = _dbContext.Ta
                .FromSqlRaw(query)
                .ToList();
            return (ta.Count() != 0);
        }

        public IEnumerable<Ta> returnAllTa(int id) 
        {
            var query =
                   $@"SELECT *
                    FROM dbo.ta ta
                    WHERE ta.Prof_Id={id} OR ta.Course_Id IS NULL";

            var ta = _dbContext.Ta
                .FromSqlRaw(query)
                .ToList();

            return ta;
        }

        public Ta GetTa(int id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.ta t
                    WHERE t.Id = {id}";

            var ta = _dbContext.Ta
                .FromSqlRaw(query)
                .ToList();

            return ta[0];
        }

        public void UpdateTa(int id, string Name, int Prof_Id, string Course_Id)
        {
            var query =
               $@"UPDATE dbo.ta
                    SET Prof_Id={Prof_Id}, Name='{Name}', Course_Id='{Course_Id}'
                    WHERE Id={id}";
            try
            {
                var ta = _dbContext.Ta
                    .FromSqlRaw(query)
                    .ToList();
            }
            catch { }
        }

        public void DeleteTa(Ta model)
        {
            _dbContext.Remove(model);
            _dbContext.SaveChanges();
        }
        public void SaveTa(Ta model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }

        #endregion

        #region course outline
        public IEnumerable<Course_Outline_Section> returnAllCourseOutline(string id)
        {
            var query =
               $@"SELECT *
                    FROM dbo.course_outline_section c
                    WHERE c.Course_Id='{id}'";

            var outline = _dbContext.Course_Outline_Section
                .FromSqlRaw(query)
                .ToList();

            return outline;
        }

        public Course_Outline_Section GetCourseOutline(int id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.course_outline_section c
                    WHERE c.Id = {id}";

            var course = _dbContext.Course_Outline_Section
                .FromSqlRaw(query)
                .ToList();

            return course[0];
        }

        public Course_Outline_Section GetCourseOutline(string Course_Id, string Part)
        {
            var query =
                $@"SELECT *
                    FROM dbo.course_outline_section c
                    WHERE c.Course_Id = '{Course_Id}' AND c.Part = '{Part}'";

            var course = _dbContext.Course_Outline_Section
                .FromSqlRaw(query)
                .ToList();

            return course[0];
        }

        public bool CheckCourseSectionPart(string Course_Id, string Part) 
        {
            var query =
                   $@"SELECT *
                    FROM dbo.course_outline_section c
                    WHERE c.Course_Id = '{Course_Id}' AND c.Part = '{Part}'";

            var course = _dbContext.Course_Outline_Section
                .FromSqlRaw(query)
                .ToList();
            return (course.Count() != 0);
        }

        public bool CheckCourseSectionPart2(string Course_Id, string Part, int id)
        {
            var query =
                   $@"SELECT *
                    FROM dbo.course_outline_section c
                    WHERE c.Course_Id = '{Course_Id}' AND c.Part = '{Part}' AND c.Id != {id}";

            var course = _dbContext.Course_Outline_Section
                .FromSqlRaw(query)
                .ToList();
            return (course.Count() != 0);
        }

        public int CheckCourseSectionPercentage(string id) 
        {
            var query =
                   $@"SELECT *
                    FROM dbo.course_outline_section c
                    WHERE c.Course_Id = '{id}'";

            var course = _dbContext.Course_Outline_Section
                .FromSqlRaw(query)
                .ToList();
            int total=0;
            for(int i=0; i <course.Count(); i++)
            {
                total = total + course[i].Percentage;
            }
            return total;
        }

        public int CheckCourseSectionPercentage(string id, int secId) 
        {
            var query =
                       $@"SELECT *
                    FROM dbo.course_outline_section c
                    WHERE c.Course_Id = '{id}' AND c.Id !={secId}";

            var course = _dbContext.Course_Outline_Section
                .FromSqlRaw(query)
                .ToList();
            int total = 0;
            for (int i = 0; i < course.Count(); i++)
            {
                total = total + course[i].Percentage;
            }
            return total;
        }

        public void CourseOutlineUpdate(int Id, string Part, int Percentage) 
        {
            var query =
                    $@"UPDATE dbo.course_outline_section
                    SET Part='{Part}', Percentage={Percentage}
                    WHERE Id = {Id}";
            try {
                var course = _dbContext.Course_Outline_Section
                        .FromSqlRaw(query)
                        .ToList();
            }
            catch { }              
            
        }

        public void SaveCourseOutline(Course_Outline_Section model)
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

        public IEnumerable<Course_Outline_Section> GetCourse_Outline_Sections(string courseId)      
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

        public Grade GetGrade2(int id)
        {
            var query =
               $@"SELECT *
                    FROM dbo.grade g
                    WHERE g.Id={id} ";

            var grade = _dbContext.Grade
                .FromSqlRaw(query)
                .ToList();
            return grade[0];
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

        public Course_Outline_Section GetCourse_Outline(int courseOutlineId) 
        {
            var query =
                       $@"SELECT *
                FROM dbo.course_outline_section c
                WHERE c.Id={courseOutlineId}";

            var components = _dbContext.Course_Outline_Section
                .FromSqlRaw(query)
                .ToList().FirstOrDefault<Course_Outline_Section>();

            return components;
        }

        public void CourseOutlineDelete(Course_Outline_Section model)
        {
            _dbContext.Remove(model);
            _dbContext.SaveChanges();
        }

        public void CourseOutlineDelete(string Course_Id)
        {
            var query =
               $@"SELECT *
                    FROM dbo.course_outline_section c
                    WHERE c.Course_Id='{Course_Id}'";

            var outline = _dbContext.Course_Outline_Section
                .FromSqlRaw(query)
                .ToList();

            for (int i=0; i < outline.Count(); i++)
            {
                _dbContext.Remove(outline[i]);
                _dbContext.SaveChanges();
            }
        }

        #endregion

        public void AddGrade(int Course_Outline_Id, string Course_Id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.takes t
                    WHERE t.Course_Id = '{Course_Id}'";

            var takes = _dbContext.Takes
                .FromSqlRaw(query)
                .ToList();

            for (int i = 0; i < takes.Count(); i++)
            {
                Grade g = new Grade();
                g.Student_Id = takes[i].Student_Id;
                g.Course_Id = takes[i].Course_Id;
                g.Course_Outline_Id = Course_Outline_Id;
                g.Editable = true;
                _dbContext.Add(g);
                _dbContext.SaveChanges();
            }
        }

        public void GradeDelete(string Course_Id)
        {
            var query =
               $@"SELECT *
                    FROM dbo.grade g
                    WHERE g.Course_Id='{Course_Id}'";

            var grade = _dbContext.Grade
                .FromSqlRaw(query)
                .ToList();

            for (int i = 0; i < grade.Count(); i++)
            {

                _dbContext.Remove(grade[i]);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteGrade(int Course_Outline_Id)
        {
            var query =
               $@"SELECT *
                    FROM dbo.grade g
                    WHERE g.Course_Outline_Id={Course_Outline_Id}";

            var grade = _dbContext.Grade
                .FromSqlRaw(query)
                .ToList();

            for (int i = 0; i < grade.Count(); i++)
            {

                _dbContext.Remove(grade[i]);
                _dbContext.SaveChanges();
            }
        }

        public Grade GetGrade(int Course_Outline_Id, int Student_Id)
        {
            var query =
               $@"SELECT *
                    FROM dbo.grade g
                    WHERE g.Course_Outline_Id={Course_Outline_Id} AND g.Student_Id={Student_Id}";

            var grade = _dbContext.Grade
                .FromSqlRaw(query)
                .ToList();
            return grade[0];
        }

        public Student GetStudent(int id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.student s
                    WHERE s.Id = {id}";

            var std = _dbContext.Student
                .FromSqlRaw(query)
                .ToList();
            return std[0];
        }

        public IEnumerable<Grade> ReturnAllGrade(int Student_Id, string Course_Id)
        {
            var query =
               $@"SELECT *
                    FROM dbo.grade g
                    WHERE g.Student_Id={Student_Id} AND g.Course_Id='{Course_Id}'";

            var grade = _dbContext.Grade
                .FromSqlRaw(query)
                .ToList();
            return grade;
        }

        public IEnumerable<Student> ReturnAllStudent(string Course_Id)
        {
            var query =
                $@"SELECT *
                    FROM dbo.takes t
                    WHERE t.Course_Id = '{Course_Id}'";

            var takes = _dbContext.Takes
                .FromSqlRaw(query)
                .ToList();
            var model = new List<Student>();

            for (int i = 0; i < takes.Count(); i++)
            {
                var query3 =
                $@"SELECT *
                    FROM dbo.student s
                    WHERE s.Id = {takes[i].Student_Id}";

                var std = _dbContext.Student
                    .FromSqlRaw(query3)
                    .ToList();
                model = model.Concat(std).ToList();

            }
            return model;
        }

        public void TakesDelete(string Course_Id)
        {
            var query =
               $@"SELECT *
                    FROM dbo.takes t
                    WHERE t.Course_Id='{Course_Id}'";

            var takes = _dbContext.Takes
                .FromSqlRaw(query)
                .ToList();

            for (int i = 0; i < takes.Count(); i++)
            {

                _dbContext.Remove(takes[i]);
                _dbContext.SaveChanges();
            }
        }

        public void TaUpdate(Ta model)
        {
            var query =
                $@"UPDATE dbo.ta 
                    SET Name='{model.Name}', Password='{model.Password}'
                    WHERE Id = {model.Id}";
            try
            {
                var ta = _dbContext.Ta
                    .FromSqlRaw(query)
                    .ToList();

            }
            catch { }

        }

        public void UpdateGrade(int id, int? Actual_Grade, bool Editable)
        {
            var query =
                    $@"UPDATE dbo.grade
                    SET Actual_Grade={Actual_Grade}, Editable='{Editable}'
                    WHERE Id = {id}";
            try
            {
                var g = _dbContext.Grade
                        .FromSqlRaw(query)
                        .ToList();
            }
            catch { }
        }

        public bool isTa(int id, string password)
        {
            var query =
                $@"SELECT *
                    FROM dbo.ta t
                    WHERE t.Id = {id} AND t.Password='{password}'";

            var ta = _dbContext.Ta
                .FromSqlRaw(query)
                .ToList();
            return (ta.Count() != 0);
        }
    }
}
