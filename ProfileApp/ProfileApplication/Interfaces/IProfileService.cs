using ProfileApplication.DTO.response;
using ProfileApplication.DTO.request;
using ProfileDomain.Models;
namespace ProfileApplication.Interfaces;

public interface IProfileService
{
    public Task<Profile> CreateProfile(Profile Profile);
}
