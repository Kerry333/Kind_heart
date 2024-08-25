using CSharpFunctionalExtensions;
using Kind_heart.Domain.ValueObjects;

namespace Kind_heart.Domain.Models.Species;

public sealed class Species : Shared.Entity<SpeciesId>
{
    private Species(SpeciesId id) : base(id)
    {
        Type = default!;
    }
    
    public SpeciesType Type { get; private set; }

    private readonly List<Breed> _breeds = [];
    public IReadOnlyList<Breed> Breeds => _breeds;

    public void AddBreed(Breed breed)
    {
        // TODO: валидацию
        _breeds.Add(breed);
    }

    private Species(SpeciesId speciesId, SpeciesType type): base(speciesId)
    {
        Type = type;
    }

    public static Result<Species> Create(SpeciesId speciesId, SpeciesType speciesType)
    {
        return new Species(speciesId, speciesType);
    }
    
}