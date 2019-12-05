using easyGrading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services.Interface
{
    public interface IClassesServices
    {
        public IEnumerable<ClassInfoViewModel> GetClassInfo(int studentId);
        public IEnumerable<ClassInfoViewModel> GetAllClasses();
        public bool AddClassToStudent(string courseId, int studentId);
        public IEnumerable<CourseComponentModel> GetCourseComponentModels(string courseId);
        public int GetCurrentGrade(string courseId);
        public void AddCourseGradeInCourseOutline(string courseId);
    }
}
