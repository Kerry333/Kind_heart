using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record Requisite
{
    public string Name { get; }
    public string Description { get;  }

    private Requisite(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static Result<Requisite, Error> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalide("Name");
        
        if (string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsInvalide("Description");
        
        return new Requisite(name, description);
       
    }
}