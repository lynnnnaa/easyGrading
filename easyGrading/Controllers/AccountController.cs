using easyGrading.Models;
using Microsoft.AspNetCore.Mvc;

namespace easyGrading.Controllers
{
    public class AccountController : Controller
    {
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
                var result = checkUser(model.UserID, model.Password);

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

        private bool checkUser(string userID, string password)
        {
            return (userID == "admin" && password == "admin");
        }

    }
}