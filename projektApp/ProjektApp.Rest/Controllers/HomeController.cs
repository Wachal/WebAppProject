using Microsoft.AspNetCore.Mvc;
using ProjektApp.Rest.Database;
using Microsoft.EntityFrameworkCore;
using ProjektApp.Rest.Models;
using ProjektApp.Rest.Database.Entities;

namespace ProjektApp.Rest.Controllers;

[Route("[controller]")]

public class HomeController : Controller
{

    public IActionResult About()
    {
        return View();
    }

}