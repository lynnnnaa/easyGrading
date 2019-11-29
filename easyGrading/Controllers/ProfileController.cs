using easyGrading.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyGrading.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult ProfileView() {

            var model = new ProfileModel()
            {
                DepartmentName = "Bachelor of Science",
                Major = "Computer Science(Major)",
                Minor = "Mathematics(Minor)",
                StudentName = "Eyal ZuriMy"
            };
            return View(model);
        }

    }
}