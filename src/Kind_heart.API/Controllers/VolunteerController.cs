using CSharpFunctionalExtensions;
using Kind_heart.API.Extensions;
using Kind_heart.Application.Volunteers.CreateVolunteer;
using Kind_heart.Domain.Models;
using Kind_heart.Domain.Models.Volunteer;
using Kind_heart.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kind_heart.API.Controllers;

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

    [HttpPost("createVolunteerHandler")] 
    [ActionName("CreateVolunteerHandler")]
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


    [HttpPost("createVolunteer")]
    [ActionName("CreateVolunteer")]
    public IActionResult Create([FromBody] CreateVolunteerDto dto)
    {
        var fullNameResult = FullName.Create(dto.FirstName, dto.MiddleName, dto.LastName);
        if (fullNameResult.IsFailure)
            return fullNameResult.Error.ToErrorResponse();

        var descriptionResult = Description.Create(dto.Description);
        if (descriptionResult.IsFailure)
            return descriptionResult.Error.ToErrorResponse();

        var experienceResult = Experience.Create(dto.Experience);
        if (experienceResult.IsFailure)
            return experienceResult.Error.ToErrorResponse();
        
        var phoneResult = Phone.Create(dto.Phone);
        if (phoneResult.IsFailure)
            return phoneResult.Error.ToErrorResponse();

        var requisiteDetails = new RequisiteDetails();
        foreach (var requisiteDto in dto.Requisites)
        {
            var requisiteResult = Requisite.Create(requisiteDto.Name, requisiteDto.Description);
            if (requisiteResult.IsFailure)
                return requisiteResult.Error.ToErrorResponse();

            requisiteDetails.AddRequisite(requisiteResult.Value);
        }

        var socialNetworkDetails = new SocialNetworkDetails();
        foreach (var socialNetworkDto in dto.SocialNetworks)
        {
            var socialNetworkResult = SocialNetwork.Create(socialNetworkDto.Name, socialNetworkDto.Path);
            if (socialNetworkResult.IsFailure)
                return socialNetworkResult.Error.ToErrorResponse();

            socialNetworkDetails.AddSocialNetwork(socialNetworkResult.Value);
        }

        var volunteerResult = new Volunteer(VolunteerId.NewVolunteerId(),
            fullNameResult.Value,
            descriptionResult.Value,
            experienceResult.Value,
            phoneResult.Value,
            requisiteDetails,
            socialNetworkDetails);

        return Ok(volunteerResult);
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


public record CreateVolunteerDto
{
    public string FirstName { get; }
    public string? MiddleName { get; }
    public string LastName { get; }
    public string Description { get; }
    public int Experience { get; }
    public string Phone { get; }

    public List<RequisiteDto> Requisites { get; }
    
    public List<SocialNetworkDto> SocialNetworks { get; }
}
