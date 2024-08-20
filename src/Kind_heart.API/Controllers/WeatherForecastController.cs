using CSharpFunctionalExtensions;
using Kind_heart.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kind_heart.API.Controllers;

public class WeatherForecastController: ControllerBase
{
    [HttpGet]

    public IActionResult Get(string name, string surname, string description)
    {
        /* с использованием кортежа
        var (pet, error) = Pet.Create(name, description);   
        if (error is not null)
        {
            return ValidationProblem();
        }
        */
        
        var volunteerResult = Volunteer.Create(VolunteerId.NewVolunteerId(), name, surname,  description);
        if (volunteerResult.IsFailure)
            return BadRequest(volunteerResult.Error);

        var result = Save(volunteerResult.Value);

        if (result.IsFailure)
            return BadRequest(result.Error);
        
        // если Save с типом void
        //Save(volunteerResult.Value); 
        
        // операция сохранения в БД
        return Ok();
    }

    public Result Save(Volunteer volunteer)
    {
        if (true)
        {
            return Result.Success();
        }
        return Result.Failure("ошибка");
    }
}