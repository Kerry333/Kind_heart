namespace Kind_heart.Domain.Models.Species;

public record SpeciesId
{
    public Guid Value { get; }
    private SpeciesId(Guid value) => Value = value;
    
    public static SpeciesId NewSpeciesId() => new(Guid.NewGuid());
    public static SpeciesId Empty() => new(Guid.Empty);
    public static SpeciesId Create(Guid id) => new(id);
    
}