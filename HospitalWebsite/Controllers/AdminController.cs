using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AdminController : Controller
{
    private readonly HospitalContext _context; // Replace 'HospitalDbContext' with the name of your DbContext class

    public AdminController(HospitalContext context)
    {
        _context = context;
    }

    public IActionResult ManageDoctors()
    {
        var doctors = _context.Doctors.ToList(); // Fetch doctors from the database
        return View(doctors);
    } 


    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Replace this with your database validation or authentication logic
        if (username == "admin" && password == "admin123") // Example credentials
        {
            HttpContext.Session.SetString("IsAdmin", "true"); // Set session
            return RedirectToAction("Dashboard");
        }

        ViewBag.Error = "Invalid credentials. Please try again.";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear(); // Clear session on logout
        return RedirectToAction("Login");
    }

    public IActionResult Dashboard()
    {
        // Protect the dashboard; allow access only for logged-in admins
        if (HttpContext.Session.GetString("IsAdmin") != "true")
        {
            return RedirectToAction("Login");
        }

        return View();
    }

    [HttpGet]
    public IActionResult AddDoctor()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddDoctor(Doctor doctor)
    {
        if (ModelState.IsValid)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return RedirectToAction("ManageDoctors");
        }
        return View(doctor);
    }

    [HttpGet]
    public IActionResult EditDoctor(int id)
    {
        var doctor = _context.Doctors.Find(id);
        if (doctor == null) return NotFound();
        return View(doctor);
    }

    [HttpPost]
    public IActionResult EditDoctor(Doctor doctor)
    {
        if (ModelState.IsValid)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
            return RedirectToAction("ManageDoctors");
        }
        return View(doctor);
    }

    [HttpPost]
    public IActionResult DeleteDoctor(int id)
    {
        var doctor = _context.Doctors.Find(id);
        if (doctor == null) return NotFound();

        _context.Doctors.Remove(doctor);
        _context.SaveChanges();
        return RedirectToAction("ManageDoctors");
    }
}


