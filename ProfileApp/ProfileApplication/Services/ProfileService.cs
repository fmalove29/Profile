using ProfileApplication.Interfaces;
using ProfileApplication.DTO.request;
using ProfileApplication.DTO.response;
using ProfileDomain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainProfile = ProfileDomain.Models.Profile;

namespace ProfileApplication.Services;

public class ProfileService : IProfileService
{
    private readonly IRepository<DomainProfile> _profileRepository;
    private readonly IMapper _mapper;

    public ProfileService(IRepository<DomainProfile> profileRepository, IMapper mapper)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
    }


    public async Task<ProfileResponse> Add(DomainProfile profile)
    {
        var entity = await _profileRepository.Add(profile);

        return _mapper.Map<ProfileResponse>(entity);
    }

    public async Task<ProfileResponse> Update(DomainProfile profile)
    {
        var entity = await _profileRepository.Update(profile);


        return _mapper.Map<ProfileResponse>(entity);
    }

    public async Task<bool> SaveChangesAsync(Guid userid)
        => await _profileRepository.SaveChangesAsync(userid);

    public async Task<ProfileResponse> FindProfileById(Guid profileId)
    {
        var entity = await _profileRepository.GetByIdAsync(profileId);

        if (entity == null)
            return null;

        return _mapper.Map<ProfileResponse>(entity);
    }

    public async Task<ProfileResponse> FindByIdWithConditionAsync(string Id)
    {
        var profile = await _profileRepository.GetByIdWithConditionAsync(Id);

        return _mapper.Map<ProfileResponse>(profile);
    }

}
