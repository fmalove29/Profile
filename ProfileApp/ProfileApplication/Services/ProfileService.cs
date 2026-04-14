using ProfileApplication.Interfaces;
using ProfileApplication.DTO.request;
using ProfileApplication.DTO.response;
using ProfileDomain.Models;

namespace ProfileApplication.Services;

public class ProfileService : IProfileService
{
    private readonly IRepository<Profile> _profileRepository;
    public ProfileService(IRepository<Profile> profileRequest)
    {
        _profileRepository = profileRequest;
    }

    public async Task<Profile> CreateProfile(Profile profile)
    {
        var prof = await _profileRepository.Add(profile);
        return prof;
    }
}
