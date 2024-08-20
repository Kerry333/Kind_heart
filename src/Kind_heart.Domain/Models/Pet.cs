using CSharpFunctionalExtensions;

namespace Kind_heart.Domain.Models;

public enum HelpStatus
{
    NeedsHelp,   // Нуждается в помощи
    LookingForHome, // Ищет дом
    FoundHome // Нашел дом
}

public class Pet : Shared.Entity<PetId>
{
    // ef core
    private Pet(PetId id) : base(id)
    {
    }

    private Pet(PetId petId, string name, string description) : base(petId)
    {
        Name = name;
        Description = description;
    }
    
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

    public RequisiteDetails RequisiteDetails { get; private set; } = default!;

    public PetPhotoDetails PetPhotoDetails { get; private set; } = default!;
    
    // Не плохой вариант:
   /* public static (Pet? Pet, string? Error) Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return (null, "Name can not be empty");
        if (string.IsNullOrWhiteSpace(description))
            return (null, "Description can not be empty");
        var pet = new Pet(name, description);
        return (pet, null);
    }
    */
   
    // Но есть хорошая альтернатива (установить пакет CsharpFunctionalExtensions):
    public static Result<Pet> Create(PetId id, string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Pet>("Name can not be empty");
        
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Pet>("Description can not be empty");
        
        var pet = new Pet(id, name, description);
        
        return Result.Success(pet);
    }

}