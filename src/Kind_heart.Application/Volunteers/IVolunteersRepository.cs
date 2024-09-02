using CSharpFunctionalExtensions;
using Kind_heart.Domain.Models.Volunteer;

namespace Kind_heart.Application.Volunteers;

public interface IVolunteersRepository
{
    Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken);
    Task<Result<Volunteer>> GetById(VolunteerId volunteerId);
}