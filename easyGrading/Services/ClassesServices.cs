using easyGrading.Models;
using easyGrading.Services.Interface;
using easyGrading.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services
{
    public class ClassesServices: IClassesServices
    {
        private IDbQueries _dbQueries;
        public ClassesServices(IDbQueries dbQueries) {
            _dbQueries = dbQueries;
        }

        public IEnumerable<ClassInfoViewModel> GetClassInfo(int studentId) 
        {
            var classes = new List<ClassInfoViewModel>();
            try
            {
                var studentTakesCourses = _dbQueries.GetStudentCourses(studentId);

                foreach (var course in studentTakesCourses)
                {
                    var studentClass = new ClassInfoViewModel();

                    var courseInfo = _dbQueries.GetCourseInfo(course.Course_Id);

                    var professorInfo = _dbQueries.GetProfessorInfo(courseInfo.Prof_Id.Value);

                    if (courseInfo.Name != null && professorInfo.Name != null) {
                        studentClass.UserId = studentId;
                        studentClass.ClassCodeName = courseInfo.Id;
                        studentClass.ClassName = courseInfo.Name;
                        studentClass.Instructor = professorInfo.Name;

                    }

                    classes.Add(studentClass);

                }

                return classes;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return classes;
            }
            
        }

        public IEnumerable<ClassInfoViewModel> GetAllClasses() 
        {
            var classes= new List<ClassInfoViewModel>();

            try
            {
                var courses = _dbQueries.GetAllCourses();
                foreach (var course in courses) 
                {
                    var studentClass = new ClassInfoViewModel();


                    var professorInfo = _dbQueries.GetProfessorInfo(course.Prof_Id.Value);
                    var taInfo = _dbQueries.GetTaInCourse(course.Id);

                    if (course.Name != null && professorInfo.Name != null)
                    {
                        studentClass.UserId = -1;
                        studentClass.ClassCodeName = course.Id;
                        studentClass.ClassName = course.Name;
                        studentClass.Instructor = professorInfo.Name;
                        studentClass.TeachingAssistant = taInfo == null ? "" : taInfo.Name;

                    }

                    classes.Add(studentClass);
                }
                return classes;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
                return classes;
            }

        }

        public bool AddClassToStudent(string courseId, int studentId) 
        {
            var studentTakes = new Takes();

            try
            {
                studentTakes.Student_Id = studentId;
                studentTakes.Course_Id = courseId;

                var studentCourses = _dbQueries.GetStudentCourses(studentId);


                var query = from student in _dbQueries.GetStudentCourses(studentId)
                            where student.Course_Id == courseId
                            select student;

                var studentData = query.FirstOrDefault<Takes>();

                if (studentData == null) {
                    _dbQueries.AddedClassToStudent(studentTakes);
                }

                return true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public IEnumerable<CourseComponentModel> GetCourseComponentModels(string courseId) 
        {
            var components = new List<CourseComponentModel>();

            try
            {
                var courseParts = _dbQueries.GetCourse_Outline_Sections(courseId);
                foreach (var part in courseParts) 
                {
                    var component = new CourseComponentModel();

                    component.Name = part.Part;

                    //get Grade status
                    var grade = _dbQueries.GetGrade(part.Id);

                    if (grade != null)
                    {
                        component.Status = grade.Editable ? "need" : "marked";
                        component.Marks = grade.Actual_Grade.HasValue ? grade.Actual_Grade.Value.ToString() : "";
                    }
                    else 
                    {
                        component.Status = "need";
                        component.Marks = "";
                    }

                    components.Add(component);
                }
                return components;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return components;
            }
        }

        public int GetCurrentGrade(string courseId) 
        {
            try
            {
                var courseGrade = _dbQueries.GetCourseGrade(courseId);
                if (courseGrade != null) 
                {
                    double result = 0;
                    double totalPercentage = 0;

                    foreach (var grade in courseGrade) 
                    {
                        var courseOutlineId = grade.Course_Outline_Id;
                        var courseOutline = _dbQueries.GetCourse_Outline(courseOutlineId);

                        if (courseOutline != null)
                        {
                            var percentage = (double)courseOutline.Percentage / 100.0;
                            var actualGrade = (double)grade.Actual_Grade.Value;

                            var temp = (actualGrade * (percentage));
                            result += temp;
                            totalPercentage += courseOutline.Percentage;
                        }
                    }

                    var finalResult = (int)((result / totalPercentage) * 100);
                    return finalResult;
                    
                }

                return 100;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
                return -1;
            }
            
        }
    }
}
