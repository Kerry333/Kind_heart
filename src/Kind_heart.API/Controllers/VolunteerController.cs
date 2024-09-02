using CSharpFunctionalExtensions;
using Kind_heart.API.Extensions;
using Kind_heart.Application.Volunteers.CreateVolunteer;
using Kind_heart.Domain.Models;
using Kind_heart.Domain.Models.Volunteer;
using Kind_heart.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kind_heart.Application.DTOs;

namespace Kind_heart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VolunteerController : ControllerBase
    {
        /*
        [HttpGet]
        public string Get()
        {
            return "Test";
        }
        */

        [HttpPost] 
    
        public async Task<ActionResult<Guid>> Create([FromServices] CreateVolunteerHandler handler,
            [FromBody] CreateVolunteerRequest request,
            CancellationToken cancellationToken)
        {
            var result = await handler.Handle(request, cancellationToken);
            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello, world!");
        }


    

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok("volunteer");
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}