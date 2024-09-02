using Kind_heart.Application.Volunteers.CreateVolunteer;

namespace Kind_heart.Application.DTOs;

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