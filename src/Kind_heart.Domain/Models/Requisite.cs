using CSharpFunctionalExtensions;

namespace Kind_heart.Domain.Models;

public record Requisite
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    private Requisite(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static Result<Requisite> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Requisite>("Name can not be empty");
        
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Requisite>("Description can not be empty");

        var requisite = new Requisite(name, description);
        return Result.Success(requisite);
    }
}