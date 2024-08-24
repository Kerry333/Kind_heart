using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record Surname
{
    public string Value { get; }

    private  Surname(string value)
    {
        Value = value;
    }

    public static Result<Surname> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Result.Failure<Surname>("Surname can not be null and within the allowed range");

        return new Surname(value);
    }
}