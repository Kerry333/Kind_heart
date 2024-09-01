using System.Runtime.InteropServices.JavaScript;
using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record PetPhoto
{
    private PetPhoto(string path)
    {
        Path = path;
    }
    public string Path { get;  }
    
    public bool IsMainPhoto { get;  } = default!;

    public static Result<PetPhoto, Error> Create(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Errors.General.ValueIsInvalide("Path");
        
        return new PetPhoto(path);
    }
}