using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;
using Kind_heart.Domain.ValueObjects;

namespace Kind_heart.Domain.Models.Volunteer;

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

    private Pet(PetId petId, 
                Name name, 
                Description description,
                PetType petType,
                Color color, 
                Health health, 
                Address address,
                Phone phone, 
                float weight, 
                float height,
                bool castrated, 
                bool vaccinated, 
                DateOnly birthday, 
                DateOnly createdDate,
                HelpStatus status) : base(petId)
    {
        Name = name;
        Description = description;
        PetType = petType;
        Color = color;
        Health = health;
        Address = address;
        Phone = phone;
        Weight = weight;
        Height = height;
        Castrated = castrated;
        Vaccinated = vaccinated;
        Birthday = birthday;
        CreatedDate = createdDate;
        Status = status;
    }
    
    public Name Name { get; private set; } = default!;
    public Description Description { get; private set; } = default!;
    
    public PetType PetType { get; private set; } = default!;
    public Color Color { get; private set; } = default!;
    public Health Health { get; private set; } = default!;
    public Address Address { get; private set; } = default!;
    public Phone Phone { get; private set; } = default!;
    
    public float Weight { get; private set; } = default!;
    public float Height { get; private set; } = default!;
    
    public bool Castrated { get; private set; } 
    public bool Vaccinated { get; private set; } 
    
    public DateOnly Birthday { get; private set; } 
    public DateOnly CreatedDate { get; private set; } = default!;
    public HelpStatus Status { get; private set; } = default!;

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
    public static Result<Pet, Error> Create(PetId id, 
                                    Name name, 
                                    Description description,
                                    PetType petType,
                                    Color color, 
                                    Health health, 
                                    Address address,
                                    Phone phone, 
                                    float weight, 
                                    float height,
                                    bool castrated, 
                                    bool vaccinated,
                                    DateOnly birthday, 
                                    DateOnly createdDate,
                                    HelpStatus helpStatus)
    
    
    {
        if(weight <= 0)
            return Errors.General.ValueIsInvalide("Weight");
        
        if(height <= 0)
            return Errors.General.ValueIsInvalide("Height");
        
        if (birthday > DateOnly.FromDateTime(DateTime.Now))
            return Errors.General.ValueIsInvalide("Birthday");
        
        if (createdDate < birthday)
            return Errors.General.ValueIsInvalide("CreatedDate");
    
        if (createdDate > DateOnly.FromDateTime(DateTime.Now))
            return Errors.General.ValueIsInvalide("CreatedDate");
        
        if (!Enum.IsDefined(typeof(HelpStatus), helpStatus))
            return Errors.General.ValueIsInvalide("HelpStatus");
        
        
        var pet = new Pet(id,
                        name, 
                        description,
                        petType, 
                        color, 
                        health, 
                        address, 
                        phone, 
                        weight, 
                        height,
                        castrated, 
                        vaccinated,
                        birthday, 
                        createdDate, 
                        helpStatus);

        return pet;
    }

}