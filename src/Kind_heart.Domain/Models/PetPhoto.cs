using CSharpFunctionalExtensions;

namespace Kind_heart.Domain.Models;

public record PetPhoto
{
    private PetPhoto(string path)
    {
        Path = path;
    }
    public string Path { get;  }
    
    public bool IsMainPhoto { get; private set; } = default!;

    public static Result<PetPhoto> Create(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return Result.Failure<PetPhoto>("Path can not be empty");
        }

        return new PetPhoto(path);
    }
}