using Microsoft.AspNetCore.Mvc;
using ProjektApp.Rest.Database;
using Microsoft.EntityFrameworkCore;
using ProjektApp.Rest.Models;
using ProjektApp.Rest.Database.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    // public IActionResult Index()
    // {
    //     return View();
    // }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var people = await db.People.ToListAsync();
        return View();
        
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
}