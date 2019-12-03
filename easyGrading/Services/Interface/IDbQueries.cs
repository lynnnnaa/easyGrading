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
        public Department GetDepartmentInfo(int id);
        public IEnumerable<Course> returnAllCourse(int id);
        public bool isProf(int id);
        public bool isProf(int id, string password);
        public void SaveStudent(Student model);
        public bool isAdmin(int id, string password);
        public Department returnDepartName(int id);
        public IEnumerable<Professor> returnAllProfessor();
        public IEnumerable<Professor> returnAllProfessor2();
        public bool checkCourseName(string name);
        public bool CheckCourseId(string id);
        public void SaveCourse(Course model);
        public bool checkDepartmentName(string name);
        public bool CheckDepartmentId(int id);
        public void SaveDepartment(Department model);
        public Course GetCourse(string id);
        public Admin GetAdmin(int id);
        public void SaveProfessor(Professor model);
        public void AdminUpdate(Admin model);
        public void ProfessorUpdate(Professor model);
        public void DepartmentUpdate(Department model);
        public void DepartmentDelete(Department model);
        public void ReSignCourseDepartment(int id);
        public void CourseUpdate(Course model);
        public void CourseDelete(Course model);
        public void ReSignStudentMajor(int id);
        public void SaveWorkin(Work_in model);
        public void ReSignTa(string id);
        public void WorkInDelete(int id, string column);
        public IEnumerable<Work_in> returnAllWorkIn(int id);
        public Professor GetProf(int id);

        public void ReSignCourseProf(int id);
        public void ReSignTaProf_Id(int id);
        public void ProfessorDelete(Professor model);

        public bool CheckWorkIn(int prof_id, int Dep_Id);
        public Work_in GetWorkIn(int Prof_Id, int Dep_Id);
        public void WorkInDelete2(int Profid, int Depid);
        public void WorkInUpdate(int Prof_Id, int Old, int Dep_Id);
        public bool isStudent(int id);
        public bool isAdmin(int id);
        public IEnumerable<Course> returnAllProfessorCourse(int id);
        public IEnumerable<Course_Outline_Section> returnAllCourseOutline(string id);
        public Course_Outline_Section GetCourseOutline(int id);
        public bool CheckCourseSectionPart(string Course_Id, string Part);
        public bool CheckCourseSectionPart2(string Course_Id, string Part, int id);
        public int CheckCourseSectionPercentage(string id);
        public int CheckCourseSectionPercentage(string id, int secId);
        public void CourseOutlineUpdate(int Id, string Part, int Percentage);
        public void SaveCourseOutline(Course_Outline_Section model);
        public void CourseOutlineDelete(Course_Outline_Section model);
        public void CourseOutlineDelete(string Course_Id);
        public IEnumerable<Takes> GetStudentCourses(int studentId);
        public Course GetCourseInfo(string courseId);
        public Professor GetProfessorInfo(int profId);
        public IEnumerable<Course> GetAllCourses();
        public void AddedClassToStudent(Takes model);
        public Ta GetTaInCourse(string courseId);
        public IEnumerable<Course_outline_section> GetCourse_Outline_Sections(string courseId);
        public Grade GetGrade(int courseOutlineId);
        public IEnumerable<Grade> GetCourseGrade(string courseId);
        public Course_outline_section GetCourse_Outline(int courseOutlineId);
        public bool isTa(int id);
        public void SaveTa(Ta model);
        public IEnumerable<Ta> returnAllTa(int id);
        public void DeleteTa(Ta model);
        public Ta GetTa(int id);
        public void UpdateTa(int id, string Name, int Prof_Id, string Course_Id);
    }
}
