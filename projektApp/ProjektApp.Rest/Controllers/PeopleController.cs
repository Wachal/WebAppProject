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
            throw new Exception("Błąd");
        }

        var personEntity = new PersonEntity(request.FirstName, request.LastName, request.CardNumber, false);
        db.People.Add(personEntity);
        await db.SaveChangesAsync();

        return Ok();
    }
}