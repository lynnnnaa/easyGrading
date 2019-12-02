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
        [Route("ClassesView/{userId}")]
        public IActionResult ClassesView(int userId) {

            var model = _classesServices.GetClassInfo(userId);
            return View(model);
        }

    }
}