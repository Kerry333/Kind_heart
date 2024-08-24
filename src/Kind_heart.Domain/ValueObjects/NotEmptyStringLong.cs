using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record NotEmptyStringLong
{
    public string Value { get; }

    private NotEmptyStringLong(string value)
    {
        Value = value;
    }

    public static Result<NotEmptyStringLong> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length > Constants.MAX_HIGH_TEXT_LENGTH)
            return Result.Failure<NotEmptyStringLong>("This field can not be null or within the allowed range.");
        return new NotEmptyStringLong(value);
    }
}