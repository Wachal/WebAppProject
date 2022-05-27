using Microsoft.AspNetCore.Mvc;
using ProjektApp.Rest.Database;
using Microsoft.EntityFrameworkCore;

namespace ProjektApp.Rest.Controllers;

[ApiController]
[Route("[controller]")]

public class PeopleController : ControllerBase
{

    private readonly PeopleDb db;

    public PeopleController(PeopleDb db)
    {
        this.db = db;
    }

    [HttpGetS]
    public async Task<IActionResult> Get()
    {
        var people = await db.People.ToListAsync();
        return Ok(people);
    }
}