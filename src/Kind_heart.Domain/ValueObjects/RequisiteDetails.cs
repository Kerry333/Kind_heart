namespace Kind_heart.Domain.ValueObjects;

public record RequisiteDetails
{
    private readonly List<Requisite> _requisites = [];
    public IReadOnlyList<Requisite> Requisites  => _requisites;
    
    public void AddRequisite(Requisite requisite)
    {
        // TODO: валидацию
        _requisites.Add(requisite);
    }
}