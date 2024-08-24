using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record FullName
{
    public Name FirstName { get; }  // так как record Name я создавала и для Pet, то почему бы его здесь не использовать
    public string MiddleName { get; }
    public Name LastName { get; } 

    private  FullName(Name firstName,
                        string middleName,
                        Name lastName)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
    }

    public static Result<FullName> Create(Name firstName,
                                            string middleName,
                                            Name lastName)
    {
        if(middleName.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Result.Failure<FullName>("Middlename is invalid");

        return new FullName(firstName, middleName, lastName);
    }
}