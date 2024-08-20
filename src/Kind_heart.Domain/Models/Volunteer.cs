using CSharpFunctionalExtensions;

namespace Kind_heart.Domain.Models;

public class Volunteer: Shared.Entity<VolunteerId>
{
    // ef core
    private Volunteer(VolunteerId id) : base(id)
    {
    }
    public VolunteerId Id { get; private set; }

    public string Name { get; private set; }
    public string Surname { get; private set; }
    
    public string Description { get; private set; }
    public float Experience { get; private set; } = default!;
    
    public int AdoptedAnimalsCount { get; private set; } = default!;
    public int AnimalsNeedingHomeCount { get; private set; } = default!;
    public int AnimalsInCareCount { get; private set; } = default!;

    public string Phone { get; private set; } = default!;
    
    public SocialNetworkDetails SocialNetworkDetails { get; private set; } = default!;

    public RequisiteDetails RequisiteDetails { get; private set; } = default!;
    
    private readonly List<Pet> _pets = [];
    public IReadOnlyList<Pet> Pet => _pets;

    public void AddPet(Pet pet)
    {
        // TODO: валидацию
        _pets.Add(pet);
    }
    
    private Volunteer(VolunteerId volunteerId ,string name, string surname, string description) : base(volunteerId)
    {
        Id = volunteerId;
        Name = name;
        Surname = surname;
        Description = description;
    }
    public static Result<Volunteer> Create(VolunteerId volunteerId, string name, string surname, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Volunteer>("Name can not be empty");
        
        if (string.IsNullOrWhiteSpace(surname))
            return Result.Failure<Volunteer>("Surname can not be empty");
        
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Volunteer>("Description can not be empty");
        
        var volunteer = new Volunteer(volunteerId ,name, surname, description);
        
        return Result.Success(volunteer);
    }

}