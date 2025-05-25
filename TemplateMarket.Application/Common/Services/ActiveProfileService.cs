using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Common.Services;

public class ActiveProfileService(
    IHttpContextAccessor _httpContext,
    //ICacheService _cacheService,
    IRepository _repo
) : IActiveProfileService
{
    public long UserId => long.Parse(_httpContext.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    public async Task<AvailableProfileResponse> GetCurrentProfile()
    {
        var user = await GetUser();

        var userCompanies = _repo.Query<UserCompany>()
            .ToList();

        var userCompany = userCompanies?
            .FirstOrDefault(x => x.UserId == UserId && x.IsActive);

        ActiveProfileResponse current = null;

        List<ProfileResponse> profiles = [];

        if (userCompany == null)
        {
            var userRoles = user.UserGroups
                .SelectMany(ug => ug.Group.GroupRoles)
                .Select(gr => gr.Role.Name)
                .Distinct()
                .ToList();

            current = new ActiveProfileResponse(
                user.Entity.Name,
                user.Entity.Identification,
                user.Entity.Type.ToString(),
                user.Entity.CreatedDate,
                userRoles
            );
        } else { 
            var userCompanyRoles = userCompany?.
                UserCompanyGroups
                .SelectMany(ug => ug.Group.GroupRoles)
                .Select(gr => gr.Role.Name)
                .Distinct()
                .ToList();

            current = new ActiveProfileResponse(
                userCompany.Company.Entity.Name,
                userCompany.Company.Entity.Identification,
                userCompany.Company.Entity.Type.ToString(),
                userCompany.Company.Entity.CreatedDate,
                userCompanyRoles
            );

            profiles.Add(new ProfileResponse(
                user.Entity.Name,
                user.Entity.Identification,
                user.Entity.Type.ToString(),
                user.Entity.CreatedDate
            ));
        }

        profiles.AddRange(userCompanies
            .Where(uc => uc.UserId == UserId)
            .Select(uc => new ProfileResponse(
                uc.Company.Entity.Name,
                uc.Company.Entity.Identification,
                uc.Company.Entity.Type.ToString(),
                uc.CreatedDate
            )));

        return new AvailableProfileResponse(profiles, current);
    }

    public async Task<User> GetUser()
        => await _repo.SingleOrThrow<User>(x => x.Id == UserId)
                   ?? throw new NotFoundException(nameof(User));

    public void SetActiveProfile(string? companyIdentification)
    {
        var userCompanies = _repo.Query<UserCompany>()
            .Where(x => x.UserId == UserId)
            .ToList();

        if(!userCompanies.Any(uc => uc.Company.Entity.Identification == companyIdentification))
            throw new NotFoundException(nameof(UserCompany)); 

        foreach (var uc in userCompanies)
        {
            uc.IsActive = (companyIdentification != null && uc.Company.Entity.Identification == companyIdentification);
        }
    }
}
