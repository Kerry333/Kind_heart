using CSharpFunctionalExtensions;
using Kind_heart.Domain.Models.Species;

namespace Kind_heart.Domain.ValueObjects;

public record PetType
{
    public SpeciesId SpeciesId { get; }
    public Guid BreedId { get; }

    private PetType(SpeciesId speciesId, Guid breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }

    public static Result<PetType> Create(SpeciesId speciesId, Guid breedId)
    {
        return new PetType(speciesId, breedId);
    }
}