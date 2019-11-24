using easyGrading.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EasyGrading.Controllers
{
    public class MainScreenController : Controller
    {
        public IActionResult MainScreenView()
        {
            var model = new List<ClassInfoViewModel>(){
                new ClassInfoViewModel() {
                    ClassCodeName = "CPSC 571",
                    ClassName = "Design and Implementation of Database Systems",
                    Instructor = "Ken Barker",
                    TeachingAssistant = "Tamer Jarada"
                },
                new ClassInfoViewModel() {
                    ClassCodeName = "CPSC 575",
                    ClassName = "iProgramming for Creative Minds",
                    Instructor = "Alexander Ivanov",
                    TeachingAssistant = "None"
                },
                new ClassInfoViewModel() {
                    ClassCodeName = "ART 345",
                    ClassName = "Anatomical Drawing I",
                    Instructor = "Kim Huynh",
                    TeachingAssistant = "None"
                },
                new ClassInfoViewModel() {
                    ClassCodeName = "PHIL 305",
                    ClassName = "The Seventh and Eighteenth Centuries",
                    Instructor = "J.J. Macintosh",
                    TeachingAssistant = "None"
                },
                new ClassInfoViewModel() {
                    ClassCodeName = "PHIL 314",
                    ClassName = "Information Technology Ethics",
                    Instructor = "Reid Buchanan",
                    TeachingAssistant = "None"
                },
                 new ClassInfoViewModel() {
                    ClassCodeName = "PHIL 305",
                    ClassName = "The Seventh and Eighteenth Centuries",
                    Instructor = "J.J. Macintosh",
                    TeachingAssistant = "None"
                },
                  new ClassInfoViewModel() {
                    ClassCodeName = "PHIL 305",
                    ClassName = "The Seventh and Eighteenth Centuries",
                    Instructor = "J.J. Macintosh",
                    TeachingAssistant = "None"
                },
                   new ClassInfoViewModel() {
                    ClassCodeName = "PHIL 305",
                    ClassName = "The Seventh and Eighteenth Centuries",
                    Instructor = "J.J. Macintosh",
                    TeachingAssistant = "None"
                }
                };
            return View(model);
        }

        private object IEnumerable<T>()
        {
            throw new NotImplementedException();
        }
    }
}