namespace Kind_heart.Domain.Models;

public class Volunteer
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = default!;
    public string Surname { get; private set; } = default!;
    
    public string Description { get; private set; } = default!;
    public float Experience { get; private set; } = default!;
    
    public int AdoptedAnimalsCount { get; private set; } = default!;
    public int AnimalsNeedingHomeCount { get; private set; } = default!;
    public int AnimalsInCareCount { get; private set; } = default!;

    public string Phone { get; private set; } = default!;

    public List<SotialNetwork> SotialNetworks { get; private set; } = [];
    public List<Requisite> Requisites { get; private set; } = [];
    public List<Pet> Pets { get; private set; } = [];

}