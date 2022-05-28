using Microsoft.AspNetCore.Mvc;
using ProjektApp.Rest.Database;
using Microsoft.EntityFrameworkCore;
using ProjektApp.Rest.Models;
using ProjektApp.Rest.Database.Entities;

namespace ProjektApp.Rest.Controllers;

[Route("[controller]")]

public class HomeController : Controller
{

    public IActionResult Index()
    {
        // var html = System.IO.File.ReadAllText(@"./Views/Home/Index.html");
        // return base.Content(html, "text/html");
        return View("~/Views/Home/Index.cshtml");
    }

   

}

