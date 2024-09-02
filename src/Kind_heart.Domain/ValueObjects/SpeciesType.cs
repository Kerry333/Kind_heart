using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record SpeciesType
{
    public string Value { get; }

    private SpeciesType(string value)
    {
        Value = value;
    }
    
    public static Result<SpeciesType, Error> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalide("SpeciesType");

        return new SpeciesType(value);
    }
}