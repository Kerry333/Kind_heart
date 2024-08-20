using CSharpFunctionalExtensions;

namespace Kind_heart.Domain.Models;

public record SocialNetwork
{
    public string Name { get; private set; }
    public string Path { get; private set; } 

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