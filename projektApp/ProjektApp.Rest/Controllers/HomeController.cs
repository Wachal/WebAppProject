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

       foreach(var card in CardEntries)
       {
           Entries.Add(card.CardEntryId + " " + card.CardNumber + " " + card.CreatedOn);
       }

        ViewBag.Entries = Entries;

        var timeEntriesList = db.CardTimes.FromSqlRaw(
            @"SELECT
            CardNumber, 
            SUM(timeDifference) AS TimeInSeconds 
        FROM(
            SELECT 
                CardNumber, 
                CreatedOn, 
                DATEDIFF(second, LAG(CreatedOn) OVER(PARTITION BY CardNumber ORDER BY CreatedOn), CreatedOn) AS timeDifference,
                ROW_NUMBER() OVER(PARTITION BY [CardNumber] ORDER BY [CreatedOn]) AS rowNumberForCard
            FROM [dbo].[CardEntries]
        ) AS CalucateTimeDiff
        WHERE rowNumberForCard%2=0
        GROUP BY CardNumber"
        ).ToList();

        ViewBag.TimeEntries = timeEntriesList;

        return View();
    }

}
