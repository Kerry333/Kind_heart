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

    public static Result<Phone, Error> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalide("Phone");

        return new Phone(value);
    }
}