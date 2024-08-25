using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record Phone
{
    public string Value { get; }

    private  Phone(string value)
    {
        Value = value;
    }

    public static Result<Phone> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Result.Failure<Phone>("Name can not be null and within the allowed range");

        return new Phone(value);
    }
}