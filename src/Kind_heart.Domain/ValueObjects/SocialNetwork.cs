using CSharpFunctionalExtensions;

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

    public static Result<SocialNetwork> Create(string name, string path)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<SocialNetwork>("Name can not be empty");
        
        if (string.IsNullOrWhiteSpace(path))
            return Result.Failure<SocialNetwork>("Path can not be empty");

        var socialNetwork = new SocialNetwork(name, path);
        return Result.Success(socialNetwork);
    }
}