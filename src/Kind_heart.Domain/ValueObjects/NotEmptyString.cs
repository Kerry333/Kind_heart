using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record NotEmptyString
{
    public string Value { get; }

    private NotEmptyString(string value)
    {
        Value = value;
    }

    public static Result<NotEmptyString> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Result.Failure<NotEmptyString>("This field can not be null or within the allowed range.");
        return new NotEmptyString(value);
    }
}