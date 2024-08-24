using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record Name
{
    public string Value { get; }

    private  Name(string value)
    {
        Value = value;
    }

    public static Result<Name> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Result.Failure<Name>("Name can not be null and within the allowed range");

        return new Name(value);
    }
}