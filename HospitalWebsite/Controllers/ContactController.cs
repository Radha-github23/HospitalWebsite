using Microsoft.AspNetCore.Mvc;

namespace HospitalWebsite.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
