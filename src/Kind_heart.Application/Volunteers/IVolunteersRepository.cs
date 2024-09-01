using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Kind_heart.Domain.Models.Volunteer;

namespace Kind_heart.Infrastructure.Repositories;

public interface IVolunteersRepository
{
    Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken);
    Task<Result<Volunteer>> GetById(VolunteerId volunteerId);
}