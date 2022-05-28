using Microsoft.AspNetCore.Mvc;
using ProjektApp.Rest.Database;
using Microsoft.EntityFrameworkCore;
using ProjektApp.Rest.Models;
using ProjektApp.Rest.Database.Entities;
using System.Text.Json;


namespace ProjektApp.Rest.Controllers;

[Route("[controller]")]

public class HomeController : Controller
{

    private readonly ProjectContext db;

    public HomeController(ProjectContext db)
    {
        this.db = db;
    }

    public IActionResult Index()
    {

        var CardEntries =  db.CardEntries.ToList();

        var Entries = new List<string>();

       foreach(var tak in CardEntries)
       {
           Entries.Add(tak.CardEntryId + " " + tak.CardNumber + " " + tak.CreatedOn);
       }

        ViewBag.Wejscia = Entries;
        return View();
    }
}

