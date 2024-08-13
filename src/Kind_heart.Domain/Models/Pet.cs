namespace Kind_heart.Domain.Models;

public enum HelpStatus
{
    NeedsHelp,   // Нуждается в помощи
    LookingForHome, // Ищет дом
    FoundHome // Нашел дом
}

public class Pet
{
    public Guid Id { get; private set; }
    
    public string Name { get; private set; } = default!;
    public string Specie { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string Breed { get; private set; } = default!;
    public string Color { get; private set; } = default!;
    public string Health { get; private set; } = default!;
    public string Address { get; private set; } = default!;
    public string Phone { get; private set; } = default!;
    
    public float Weight { get; private set; } = default!;
    public float Height { get; private set; } = default!;
    
    public bool Castrated { get; private set; } = default!;
    public bool Vaccinated { get; private set; } = default!;
    
    public DateOnly Birthday { get; private set; } = default!;
    public DateOnly CreatedDate { get; private set; } = default!;
    
    public HelpStatus Status { get; private set; } = HelpStatus.NeedsHelp;
    public List<Requisite> Requisites { get; private set; } = [];

}