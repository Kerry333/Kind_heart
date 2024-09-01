using Kind_heart.Domain.ValueObjects;

namespace Kind_heart.Application.Volunteers.CreateVolunteer;


public record CreateVolunteerRequest(string FirstName,
                                    string? MiddleName,
                                    string LastName,
                                    string Description,
                                    int Experience,
                                    string Phone,
                                    List<RequisiteDto> Requisites,
                                    List<SocialNetworkDto> SocialNetworks);

public record RequisiteDto(string Name, string Description);
public record SocialNetworkDto(string Name, string Path);