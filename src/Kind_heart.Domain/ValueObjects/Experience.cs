using System.Runtime.InteropServices.JavaScript;
using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record 
    
    Experience
{
    public int Value { get; }

    private  Experience(int value)
    {
        Value = value;
    }

    public static Result<Experience, Error> Create(int value)
    {
        if(value < 0)
            return Errors.General.ValueIsInvalide("Experience");

        return new Experience(value);
    }
}