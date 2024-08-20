namespace Kind_heart.Domain.Models;

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