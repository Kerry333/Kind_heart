using CSharpFunctionalExtensions;
using Kind_heart.Domain.Models.Volunteer;
using Kind_heart.Domain.Shared;
using Kind_heart.Domain.ValueObjects;
using Kind_heart.Infrastructure.Repositories;

namespace Kind_heart.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerHandler
{
    private readonly IVolunteersRepository _volunteersRepository;

    public CreateVolunteerHandler(IVolunteersRepository volunteersRepository)
    {
        _volunteersRepository = volunteersRepository;
    }
    
    public async Task<Result<Guid, Error>> Handle(CreateVolunteerRequest request,
                                                    CancellationToken cancellationToken)
    {
        var volunteerId = VolunteerId.NewVolunteerId();

        var fullNameResult = FullName.Create(request.FirstName, request.MiddleName, request.LastName);
        if (fullNameResult.IsFailure)
            return fullNameResult.Error;

        var descriptionResult = Description.Create(request.Description);
        if (descriptionResult.IsFailure)
            return descriptionResult.Error;

        var experienceResult = Experience.Create(request.Experience);
        if (experienceResult.IsFailure)
            return experienceResult.Error;

        var phoneResult = Phone.Create(request.Phone);
        if (phoneResult.IsFailure)
            return phoneResult.Error;
        
        var requisiteDetails = new RequisiteDetails();
        foreach (var requisiteDto in request.Requisites)
        {
            var requisiteResult = Requisite.Create(requisiteDto.Name, requisiteDto.Description);
            if (requisiteResult.IsFailure)
                return requisiteResult.Error;

            requisiteDetails.AddRequisite(requisiteResult.Value);
        }
        
        var socialNetworkDetails = new SocialNetworkDetails();
        foreach (var socialNetworkDto in request.SocialNetworks)
        {
            var socialNetworkResult = SocialNetwork.Create(socialNetworkDto.Name, socialNetworkDto.Path);
            if (socialNetworkResult.IsFailure)
                return socialNetworkResult.Error;

            socialNetworkDetails.AddSocialNetwork(socialNetworkResult.Value);
        }
        
        var volunteer = new Volunteer(volunteerId,
            fullNameResult.Value,
            descriptionResult.Value,
            experienceResult.Value,
            phoneResult.Value,
            requisiteDetails, 
            socialNetworkDetails);

        await _volunteersRepository.Add(volunteer, cancellationToken);
        
        return (Guid)volunteer.Id;
    }
}