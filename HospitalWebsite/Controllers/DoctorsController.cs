using Microsoft.AspNetCore.Mvc;

namespace HospitalWebsite.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
