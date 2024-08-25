using CSharpFunctionalExtensions;
using Kind_heart.Domain.Models;
using Kind_heart.Domain.Models.Volunteer;
using Kind_heart.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kind_heart.API.Controllers;
public class VolunteerController: ControllerBase
{
    [HttpGet]

    public IActionResult Get(FullName fullName, Description description, Experience experience, Phone phone)
    {
        
        var volunteerResult = Volunteer.Create(VolunteerId.NewVolunteerId(), 
                                                fullName,
                                                description, 
                                                experience, 
                                                phone );
        
        if (volunteerResult.IsFailure)
            return BadRequest(volunteerResult.Error);

       // var result = Save(volunteerResult.Value);

        //if (result.IsFailure)
         //   return BadRequest(result.Error);
        
        // если Save с типом void
        //Save(volunteerResult.Value); 
        
        // операция сохранения в БД
        return Ok();
    }
/*
    public Result Save(Volunteer volunteer)
    {
        if (true)
        {
            return Result.Success();
        }
        return Result.Failure("ошибка");
    }
    */
}