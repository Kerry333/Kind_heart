namespace Kind_heart.Domain.ValueObjects;

public record PetPhotoDetails
{
    private readonly List<PetPhoto> _petPhotos = [];
    public IReadOnlyList<PetPhoto> PetPhotos => _petPhotos;

    public void AddPhoto(PetPhoto petPhoto)
    {
        // TODO: валидацию
        _petPhotos.Add(petPhoto);
    }

}