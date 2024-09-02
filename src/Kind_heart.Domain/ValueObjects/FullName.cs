using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record FullName
{
    public string FirstName { get; }  
    public string? MiddleName { get; }
    public string LastName { get; } 

    private  FullName(string firstName,
                        string? middleName,
                        string lastName)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
    }

    public static Result<FullName, Error> Create(string firstName,
                                            string? middleName,
                                           string lastName)
    {
        if(!string.IsNullOrEmpty(middleName) && middleName.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalide("MiddleName");

        return new FullName(firstName, middleName, lastName);
    }
}