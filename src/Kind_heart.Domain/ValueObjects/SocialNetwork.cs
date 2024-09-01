using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record SocialNetwork
{
    public string Name { get; }
    public string Path { get; } 

    private SocialNetwork(string name, string path)
    {
        Name = name;
        Path = path;
    }

    public static Result<SocialNetwork, Error> Create(string name, string path)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalide("Name");
        
        if (string.IsNullOrWhiteSpace(path))
            return Errors.General.ValueIsInvalide("Path");

        var socialNetwork = new SocialNetwork(name, path);
        return new SocialNetwork(name, path);
    }
}