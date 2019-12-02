using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using easyGrading.Models;
using easyGrading.Services.Interface;
using Microsoft.AspNetCore.Mvc;

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
                TempData["Message2"] = "invalid percentage; pleace enter numbers less then"+(100-total);
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
                TempData["Message2"] = "invalid percentage; pleace enter numbers less then" + (100 - total);
            }
            else
            {
                if (!result)
                {
                    Course_Outline_Section outline = new Course_Outline_Section();
                    outline.Prof_Id = ID;
                    outline.Course_Id = CourseId;
                    outline.Part = model.Part;
                    outline.Percentage = model.Percentage;
                    _dbQueries.SaveCourseOutline(outline);
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
            model.Id = ID;
            _dbQueries.ProfessorUpdate(model);
            TempData["SuccessMessage"] = "Account has been updated Successfully";
            return View(model);
        }

        #endregion
    }
}