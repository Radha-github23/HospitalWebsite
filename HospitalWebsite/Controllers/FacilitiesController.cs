﻿using Microsoft.AspNetCore.Mvc;

namespace HospitalWebsite.Controllers
{
    public class FacilitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
