namespace Kind_heart.Domain.Models;

public record SocialNetworkDetails
{
    private readonly List<SocialNetwork> _socialNetworks = [];
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

    public void AddSocialNetwork(SocialNetwork socialNetwork)
    {
        // TODO: валидацию
        _socialNetworks.Add(socialNetwork);
    }

}