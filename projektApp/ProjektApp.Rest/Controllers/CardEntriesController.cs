using Microsoft.AspNetCore.Mvc;
using ProjektApp.Rest.Database;
using Microsoft.EntityFrameworkCore;
using ProjektApp.Rest.Models;
using ProjektApp.Rest.Database.Entities;

namespace ProjektApp.Rest.Controllers;

[ApiController]
[Route("[controller]")]

public class CardEntriesController : ControllerBase
{

    private readonly ProjectContext db;

    public CardEntriesController(ProjectContext db)
    {
        this.db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var CardEntries = await db.CardEntries.ToListAsync();
        return Ok(CardEntries);
    }

    [HttpPost]
    public async Task <IActionResult> Add([FromBody] CreateCardRequest request)
    {
        if(!request.Validate())
        {
            throw new Exception("cos tam zle");
        }

        var CardEntity = new CardEntity(request.CardNumber);
        db.CardEntries.Add(CardEntity);
        await db.SaveChangesAsync();

        return Ok();
    }
}