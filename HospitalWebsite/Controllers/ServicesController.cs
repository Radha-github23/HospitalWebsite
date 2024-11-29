using Microsoft.AspNetCore.Mvc;

namespace HospitalWebsite.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
