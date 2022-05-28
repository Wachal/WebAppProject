using Microsoft.AspNetCore.Mvc;
using ProjektApp.Rest.Database;
using Microsoft.EntityFrameworkCore;
using ProjektApp.Rest.Models;
using ProjektApp.Rest.Database.Entities;

namespace ProjektApp.Rest.Controllers;

[ApiController]
[Route("[controller]")]

public class PeopleController : ControllerBase
{

    private readonly ProjectContext db;

    public PeopleController(ProjectContext db)
    {
        this.db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var people = await db.People.ToListAsync();
        return Ok(people);
    }

    [HttpPost]
    public async Task <IActionResult> Add([FromBody] CreatePersonRequest request)
    {
        if(!request.Validate())
        {
            throw new Exception("cos tam zle");
        }

        var personEntity = new PersonEntity(request.FirstName, request.LastName, request.PhoneNumber);
        db.People.Add(personEntity);
        await db.SaveChangesAsync();

        return Ok();
    }

    // [HttpPost]
    // [Route("asdasd")]
    // public async Task <IActionResult> Add([FromBody] CreateCardRequest request)
    // {
    //     if(!request.Validate())
    //     {
    //         throw new Exception("cos tam zle");
    //     }

    //     var CardEntity = new CardEntity(request.CardNumber);
    //     db.CardEntries.Add(CardEntity);
    //     await db.SaveChangesAsync();

    //     return Ok();
    // }
}