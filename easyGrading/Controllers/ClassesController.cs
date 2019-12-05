using easyGrading.Models;
using easyGrading.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EasyGrading.Controllers
{
    public class ClassesController : Controller
    {
        private IClassesServices _classesServices;
        public ClassesController(IClassesServices classesServices) {
            _classesServices = classesServices;
        }

        [HttpGet]
        [Route("ClassesView")]
        public IActionResult ClassesView() {

            var userId = (int)TempData.Peek("UID");
            var model = _classesServices.GetClassInfo(userId);
            return View(model);
        }

        [HttpGet]
        [Route("AddNewClassView")]
        public IActionResult AddNewClassView() {
            var model = _classesServices.GetAllClasses();
            return View(model);
        }

        public IActionResult AddClassToUser(string course) {
            var check = _classesServices.AddClassToStudent(course,(int)TempData.Peek("UID"));
            
            return RedirectToAction("ClassesView");
        }

    }
}