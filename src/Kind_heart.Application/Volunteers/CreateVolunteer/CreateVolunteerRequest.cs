using Kind_heart.Application.DTOs;
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