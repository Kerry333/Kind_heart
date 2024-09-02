using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record BreedType
{
    public string Value { get; }

    private BreedType(string value)
    {
        Value = value;
    }

    public static Result<BreedType, Error> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalide("BreedType");

        return new BreedType(value);
    }
}