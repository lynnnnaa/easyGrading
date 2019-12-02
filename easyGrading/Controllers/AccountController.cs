using easyGrading.Models;
using easyGrading.Services.Model;
using easyGrading.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using easyGrading.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;

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

                var id = 0;

                if (Int32.TryParse(model.UserID, out id))
                {
                    if (_accountServices.isUserStudent(id, model.Password))
                    {
                        return RedirectToAction("MainScreenView", "MainScreen", model);
                    }
                    else if (_accountServices.isUserTa(id, model.Password))
                    {

                    }
                    else if (_accountServices.isUserProfessor(id, model.Password))
                    {
                    }
                    else if (_accountServices.isUserAdmin(id, model.Password)) 
                    {
                    }
                }
                
            }
            model.Error = "accountError";
            return View(model);
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
            if (model.Id > 0 && model.Password != null)
            {
                var result = _accountServices.isUserStudent(model.Id, model.Password);
                var result2 = _dbQueries.isProf(model.Id);
                var result3 = _accountServices.isUserAdmin(model.Id, model.Password);
                var result4 = _accountServices.isUserTa(model.Id, model.Password);
                if (result || result2 || result3 || result4) 
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