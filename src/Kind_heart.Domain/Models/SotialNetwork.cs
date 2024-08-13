namespace Kind_heart.Domain.Models;

public class SotialNetwork
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = default!;
    public string Path { get; private set; } = default!;
}