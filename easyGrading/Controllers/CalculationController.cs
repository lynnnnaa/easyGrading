using easyGrading.Models;
using easyGrading.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EasyGrading.Controllers
{
    public class CalculationController : Controller
    {
        private IClassesServices _classesServices;
        public CalculationController(IClassesServices classesServices)
        {
            _classesServices = classesServices;
        }
        [HttpGet]
        [Route("CalculationView/{courseId}")]
        public IActionResult CalculationView(string courseId)
        {

            var model = new CalculationModel();

            model.CourseName = courseId;
            //do calculation for current grade

            model.CurrentGrade = _classesServices.GetCurrentGrade(courseId).ToString()+"%";
            model.TargetGrade = "100%";
           // model.TargetGrade = ;

            //get all course ouline parts
            model.Components = new List<CourseComponentModel>();
            var courseComponents = _classesServices.GetCourseComponentModels(courseId);

            model.Components.AddRange(courseComponents);

            return View(model);
        }
    }
}