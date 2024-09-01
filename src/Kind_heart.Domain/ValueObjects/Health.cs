using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record Health
{
    public string Value { get; }

    private Health(string value)
    {
        Value = value;
    }

    public static Result<Health, Error> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalide("Health");

        return new Health(value);
    }
}