using CSharpFunctionalExtensions;

namespace Kind_heart.Domain.ValueObjects;

public record Experience
{
    public float Value { get; }

    private  Experience(float value)
    {
        Value = value;
    }

    public static Result<Experience> Create(float value)
    {
        if(value < 0)
            return Result.Failure<Experience>("Experience can not be less then 0");

        return new Experience(value);
    }
}