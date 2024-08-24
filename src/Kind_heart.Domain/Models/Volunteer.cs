using CSharpFunctionalExtensions;
using Kind_heart.Domain.ValueObjects;

namespace Kind_heart.Domain.Models;

public sealed class Volunteer: Shared.Entity<VolunteerId>
{
    // ef core
    private Volunteer(VolunteerId id) : base(id)
    {
        FullName = default!;  
        Description = default!;
    }

    
    public FullName FullName { get; private set; }
    public Description Description { get; private set; }
    public Experience Experience { get; private set; } = default!;
    public Phone Phone { get; private set; } = default!;

    public int AdoptedPetsCount() => Pets.Count(p => p.Status == HelpStatus.FoundHome);
    public int PetsNeedingHomeCount() => Pets.Count(p => p.Status == HelpStatus.LookingForHome);
    public int PetsInCareCount() => Pets.Count(p => p.Status == HelpStatus.NeedsHelp); 
    
    public SocialNetworkDetails SocialNetworkDetails { get; private set; } = default!;

    public RequisiteDetails RequisiteDetails { get; private set; } = default!;
    
    private readonly List<Pet> _pets = [];
    public IReadOnlyList<Pet> Pets => _pets;

    public void AddPet(Pet pet)
    {
        // TODO: валидацию
        _pets.Add(pet);
    }
    
    private Volunteer(VolunteerId volunteerId ,
                        FullName fullName, 
                        Description description,
                        Experience experience,
                        Phone phone) : base(volunteerId)
    {
        FullName = fullName;
        Description = description;
        Experience = experience;
        Phone = phone;
    }
    public static Result<Volunteer> Create(VolunteerId volunteerId,
                                            FullName fullName, 
                                            Description description,
                                            Experience experience,
                                            Phone phone)
    {
        
        return new Volunteer(volunteerId ,
                                fullName, 
                                description, 
                                experience, 
                                phone);
    }

}

