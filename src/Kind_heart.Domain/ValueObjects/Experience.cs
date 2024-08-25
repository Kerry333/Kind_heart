using CSharpFunctionalExtensions;

namespace Kind_heart.Domain.ValueObjects;

public record Experience
{
    public int Value { get; }

    private  Experience(int value)
    {
        Value = value;
    }

    public static Result<Experience> Create(int value)
    {
        if(value < 0)
            return Result.Failure<Experience>("Experience can not be less then 0");

        return new Experience(value);
    }
}