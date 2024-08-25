using CSharpFunctionalExtensions;
using Kind_heart.Domain.ValueObjects;

namespace Kind_heart.Domain.Models.Species;

public class Breed : Shared.Entity<BreedId>
{
    public Breed(BreedId id) : base(id)
    {
        Type = default!;
    }
    
    public BreedType Type { get; private set; }

    private Breed(BreedId breedId, BreedType type) : base(breedId)
    {
       Type = type;
    }

    public static Result<Breed> Create(BreedId breedId, BreedType type)
    {
        return new Breed(breedId, type);
    }
}