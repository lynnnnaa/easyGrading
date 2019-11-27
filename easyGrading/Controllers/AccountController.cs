using easyGrading.Models;
using easyGrading.Services.Model;
using easyGrading.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using easyGrading.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace easyGrading.Controllers
{
    public class AccountController : Controller
    {
        private IAccountServices _accountServices;
        // private EasyGradingContext _dbContext;
        private IDbQueries _dbQueries;

        public AccountController(IAccountServices accountServices, IDbQueries dbQueries) {
            _accountServices = accountServices;
            _dbQueries = dbQueries;
        }
        [HttpGet]
        public IActionResult SignInView(string returnUrl = "")
        {
            var model = new SignInViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult SignInView(SignInViewModel model)
        {
            //Check if all needed fields are filled
            if (ModelState.IsValid && model.UserID != null && model.Password != null)
            {
                //var result = checkUser(model.UserID, model.Password);
                var result = _accountServices.isUser(model.UserID, model.Password);

                if (result)
                {
                    return RedirectToAction("MainScreenView", "MainScreen");
                    //return RedirectToAction("temp", model);
                }
            }
            model.Error = "accountError";
            return View(model);
        }

        public IActionResult temp(SignInViewModel user)
        {
            var model = user;
            return View();
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            IEnumerable < Department > list= _dbQueries.returnAllDepartment();
            

            ViewBag.DepartmentList = new SelectList(list, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(StudentViewModel model)
        {
            IEnumerable<Department> list = _dbQueries.returnAllDepartment();

            ViewBag.DepartmentList = new SelectList(list, "Id", "Name");
            if (model.Id >0 && model.Password != null)
            {
                var result = _accountServices.isUser(model.Id.ToString(), model.Password);
                if (result) 
                {
                    TempData["Message"] = "This User Id is alredy exist";
                }
                else
                {
                    Student st = new Student();
                    st.Id = model.Id;
                    st.Password = model.Password;
                    st.FirstName = model.FirstName;
                    st.LastName = model.LastName;
                    st.Major = model.Major;
                    st.Minor = model.Minor;
                   
                    _dbQueries.SaveStudent(st);

                    TempData["SuccessMessage"] = "Account Created Successfully";

                    
                }
            }
            else
            {
                if (model.Id <= 0)
                {
                    TempData["Message"] = "User Id field cannot be empty";
                }
                if (model.Password == null)
                {
                    TempData["Message2"] = "Password field cannot be empty";
                }
            }
                return View(model);
        }


    }
}