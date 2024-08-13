namespace Kind_heart.Domain.Models;

public class PetPhoto
{
    public Guid Id { get; private set; }

    public string Path { get; private set; } = default!;
    public bool IsMainPhoto { get; private set; } = default!;
}