using easyGrading.Models;
using easyGrading.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EasyGrading.Controllers
{
    public class MainScreenController : Controller
    {
        private IClassesServices _classesServices;
        public MainScreenController(IClassesServices classesServices) {
            _classesServices = classesServices;
        }
        public IActionResult MainScreenView(SignInViewModel userModel)
        {

            var model = _classesServices.GetClassInfo(Int32.Parse(userModel.UserID));
           
            return View(model);
        }

        [HttpGet]
        [Route("MainScreenViewWithUserId/{userId}")]
        public IActionResult MainScreenViewWithUserId(int userId)
        {

            var model = _classesServices.GetClassInfo(userId);

            return View("MainScreenView", model);
        }

    }
}