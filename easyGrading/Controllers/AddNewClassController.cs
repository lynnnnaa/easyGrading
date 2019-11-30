using easyGrading.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EasyGrading.Controllers
{
    public class AddNewClassController : Controller
    {
        public IActionResult AddNewClassView() {

            var model = new List<ClassInfoViewModel>(){
                new ClassInfoViewModel() {
                    ClassCodeName = "CPSC 571",
                    ClassName = "Design and Implementation of Database Systems",
                    Instructor = "Ken Barker",
                    TeachingAssistant = "Tamer Jarada"}
                };
            return View(model);
        }

    }
}