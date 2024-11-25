using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTest.Constants;

namespace TaskTest.Controllers
{
    [Authorize(Roles = nameof(Roles.Admin))]
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }



    }
}
