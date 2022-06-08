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
            throw new Exception("Błąd");
        }

        //Find is readed cardNumber added as a user
        var person = db.People.Find(request.CardNumber);
        if (person is null)
        {
            var personToCreate = new PersonEntity("Imię", "Nazwisko", request.CardNumber, false);
            db.People.Add(personToCreate);
            db.SaveChanges();

            person = personToCreate;
        }
        
        //Send request of readed card to API
        var CardEntity = new CardEntity(request.CardNumber);
        db.CardEntries.Add(CardEntity);
        await db.SaveChangesAsync();

        //Determine if Person was working or not
        //and change working status based on previous status
        if(person.IsWorking)
            person.IsWorking = false;
        else if(person.IsWorking == false)
            person.IsWorking = true;

        //Save changes on person entity
        db.SaveChanges();
        
        return Ok(person);
    }
}