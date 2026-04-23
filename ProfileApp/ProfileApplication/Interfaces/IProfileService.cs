using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProfileApplication.DTO.response;
using ProfileApplication.DTO.request;
using ProfileDomain.Models;
using DomainProfile = ProfileDomain.Models.Profile;
namespace ProfileApplication.Interfaces;

public interface IProfileService
{
    Task<ProfileResponse> Add(Profile profile);
    Task<ProfileResponse> Update(Profile profile);
    Task<bool> SaveChangesAsync(Guid UserId);
    Task<ProfileResponse> FindProfileById(Guid profileId);
    Task<ProfileResponse> FindByIdWithConditionAsync(string Id);
}
