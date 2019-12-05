using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using easyGrading.Models;
using easyGrading.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace easyGrading.Controllers
{
    public class ProfessorController : Controller
    {
        private IDbQueries _dbQueries;
        static int ID;
        static string CourseId;
        static int SectionId;
        public ProfessorController(IDbQueries dbQueries)
        {
            _dbQueries = dbQueries;
        }
        public IActionResult ProfPage(int id)
        {
            ID = id;
            return RedirectToAction("Home", "Professor");
        }

        public IActionResult Home()
        {
            IEnumerable<Course> list = _dbQueries.returnAllProfessorCourse(ID);
            return View(list);
        }

        #region EditOutline


        [HttpGet]
        public IActionResult ViewOutline(string id)
        {
            CourseId = id;
            Course model = _dbQueries.GetCourse(id);
            IEnumerable<Course_Outline_Section> list = _dbQueries.returnAllCourseOutline(id);
            ViewBag.CourseName = model.Name;
            return View(list);
        }

        [HttpGet]
        public IActionResult EditOutline(int id)
        {
            SectionId = id;
            Course_Outline_Section model = _dbQueries.GetCourseOutline(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditOutline(Course_Outline_Section model, string button)
        {
            if (button == "delete") 
            {
                _dbQueries.DeleteGrade(SectionId);
                _dbQueries.CourseOutlineDelete(_dbQueries.GetCourseOutline(SectionId));
                
                return RedirectToAction("ViewOutline", "Professor", new { id = CourseId });
            }
            var result = true;
            if(model.Part != null)
            {
                result = _dbQueries.CheckCourseSectionPart2(CourseId, model.Part, SectionId);
                if (result) 
                { 
                    TempData["Message"] = "this section name is already exist"; 
                }
            }
            else
            {
                TempData["Message"] = "section name cannot be empty";
            }
            int total = _dbQueries.CheckCourseSectionPercentage(CourseId, SectionId);
            if (total + model.Percentage > 100) 
            {
                TempData["Message2"] = "invalid percentage; enter numbers less then"+(100-total);
            }
            else 
            {
                if (!result)
                {                    
                    _dbQueries.CourseOutlineUpdate(SectionId,model.Part,model.Percentage);
                    return RedirectToAction("ViewOutline", "Professor", new {id=CourseId });
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddOutline()
        {
            ViewBag.CourseName = _dbQueries.GetCourse(CourseId);
            return View();
        }

        [HttpPost]
        public IActionResult AddOutline(Course_Outline_Section model)
        {
            var result = true;
            if (model.Part != null)
            {
                result = _dbQueries.CheckCourseSectionPart(CourseId, model.Part);
                if (result)
                {
                    TempData["Message3"] = "this section name is already exist";
                }
            }
            else
            {
                TempData["Message3"] = "section name cannot be empty";
            }
            int total = _dbQueries.CheckCourseSectionPercentage(CourseId);
            if (total + model.Percentage > 100)
            {
                TempData["Message2"] = "invalid percentage; enter numbers less then" + (100 - total);
            }
            else
            {
                if (!result)
                {
                    Course_Outline_Section outline = new Course_Outline_Section();
                    outline.Prof_Id = 0;
                    outline.Course_Id = CourseId;
                    outline.Part = model.Part;
                    outline.Percentage = model.Percentage;
                    _dbQueries.SaveCourseOutline(outline);
                    var temp = _dbQueries.GetCourseOutline(CourseId, model.Part);
                    _dbQueries.AddGrade(temp.Id, temp.Course_Id);
                    return RedirectToAction("ViewOutline", "Professor", new {id=CourseId });
                }
            }
            return View(model);
        }

        #endregion

        #region EditAccount
        [HttpGet]
        public IActionResult EditAccount()
        {
            Professor model = _dbQueries.GetProf(ID);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditAccount(Professor model)
        {
            if (model.Name != null && model.Password != null)
            {
                model.Id = ID;
                _dbQueries.ProfessorUpdate(model);
                TempData["SuccessMessage"] = "Account has been updated Successfully";
            }
            if (model.Name == null) { TempData["message2"] = "Name cannot be null"; }
            if (model.Password == null) { TempData["message"] = "Password cannot be null"; }
            return View(model);
        }

        #endregion


        #region AddTa
        [HttpGet]
        public IActionResult AddTa()
        {
            IEnumerable<Course> list = _dbQueries.returnAllProfessorCourse(ID);
            ViewBag.CourseList = new SelectList(list, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddTa(Ta model)
        {
            if(model.Id > 0 && model.Name !=null)
            {
                var result = _dbQueries.isProf(model.Id);
                var result2 = _dbQueries.isStudent(model.Id);
                var result3 = _dbQueries.isTa(model.Id);
                if (result || result2 || result3)
                {
                    TempData["Message"] = "This Id is alredy exist";
                }
                else
                {
                    Ta ta = new Ta();
                    ta.Id = model.Id;
                    ta.Name = model.Name;
                    if (model.Password == null) { ta.Password = "temp"; }
                    else { ta.Password = model.Password; }

                    ta.Prof_Id = ID;
                    ta.Course_Id = model.Course_Id;
                    _dbQueries.SaveTa(ta);
                    return RedirectToAction("ShowTa", "Professor");
                }
            }
            else
            {
                if (model.Id <= 0)
                {
                    TempData["Message"] = "Id field cannot be empty";
                }
                if (model.Name == null)
                {
                    TempData["Message2"] = "Name field cannot be empty";
                }
            }
            IEnumerable<Course> list = _dbQueries.returnAllProfessorCourse(ID);
            ViewBag.CourseList = new SelectList(list, "Id", "Name");
            return View(model);
        }

        #endregion

        #region EditTa
        [HttpGet]
        public IActionResult ShowTa()
        {
            IEnumerable<Ta> list = _dbQueries.returnAllTa(ID);
            return View(list);
        }

        [HttpGet]
        public IActionResult EditTa(int id)
        {
            Ta model = _dbQueries.GetTa(id);
            IEnumerable<Course> list = _dbQueries.returnAllProfessorCourse(ID);
            ViewBag.CourseList = new SelectList(list, "Id", "Name", model.Course_Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditTa(Ta model, string button)
        {
            if (button == "update") {
                if (model.Name != null)
                {
                    _dbQueries.UpdateTa(model.Id, model.Name, ID, model.Course_Id);
                    return RedirectToAction("ShowTa", "Professor");

                }
                else
                {
                    TempData["Message2"] = "Name field cannot be empty";
                }
            }
            else
            {
                _dbQueries.DeleteTa(model);
                return RedirectToAction("ShowTa", "Professor");
            }
            
            IEnumerable<Course> list = _dbQueries.returnAllProfessorCourse(ID);
            ViewBag.CourseList = new SelectList(list, "Id", "Name");
            return View(model);
        }
        #endregion
    }
}