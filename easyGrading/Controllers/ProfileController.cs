using easyGrading.Models;
using easyGrading.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EasyGrading.Controllers
{
    public class ProfileController : Controller
    {
        private IAccountServices _accountServices;

        public ProfileController(IAccountServices accountServices) {
            _accountServices = accountServices;
        }

        [HttpGet]
        [Route("ProfileView/{userId}")]
        public IActionResult ProfileView(int userId)
        {

            var model = _accountServices.GetProfile(userId);
     
            return View(model);
        }

    }
}