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
            FirstName,
			LastName,
			CardNumber, 
            SUM(timeDifference) AS TimeInSeconds,
			SUM(timeDifferenceMin) AS TimeInMins,
			SUM(timeDifferenceHour) as TimeInHours
        FROM(
            SELECT 
                CardNumber AS CardNumber1, 
                CreatedOn, 
                DATEDIFF(second, LAG(CreatedOn) OVER(PARTITION BY CardNumber ORDER BY CreatedOn), CreatedOn) AS timeDifference,
				DATEDIFF(minute, LAG(CreatedOn) OVER(PARTITION BY CardNumber ORDER BY CreatedOn), CreatedOn) AS timeDifferenceMin,
				DATEDIFF(hour, LAG(CreatedOn) OVER(PARTITION BY CardNumber ORDER BY CreatedOn), CreatedOn) AS timeDifferenceHour,
                ROW_NUMBER() OVER(PARTITION BY [CardNumber] ORDER BY [CreatedOn]) AS rowNumberForCard
            FROM [dbo].[CardEntries]
        ) AS CalucateTimeDiff
		INNER JOIN [dbo].[Person] ON (Person.CardNumber = CardNumber1)
        WHERE rowNumberForCard%2=0
        GROUP BY CardNumber, FirstName, LastName"
        ).ToList();

        ViewBag.TimeEntries = timeEntriesList;

        return View();
    }

}
