using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Kind_heart.Application.Volunteers;
using Kind_heart.Domain.Models.Volunteer;
using Kind_heart.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Kind_heart.Infrastructure.Repositories;

public class VolunteersRepository : IVolunteersRepository
{
    private readonly ApplicationDbContext _dbContext;

    public VolunteersRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken)
    {
        await _dbContext.Volunteers.AddAsync(volunteer, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return volunteer.Id;
    }

    public async Task<Result<Volunteer>> GetById(VolunteerId volunteerId)
    {
        var volunteer = await _dbContext.Volunteers
                .Include(v => v.Pets)
            .FirstOrDefaultAsync(v => v.Id == volunteerId);
            

        if (volunteer is null)
        {
            return Result.Failure<Volunteer>("Volunteer is not found");
            //return volunteer.Error.ToErrorResponse();
        }

        return volunteer;
    }
}