using Microsoft.AspNetCore.Http;
using System.Security.Claims;
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
        //var companyId = await _cacheService.GetValueAsync("active-profile:CompanyId");
        var user = await _repo.GetByIdAsync<User>(UserId);

        var userCompanies = _repo.Query<UserCompany>().AsEnumerable();

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
            .Where(uc => uc.Id == UserId)
            .Select(uc => new ProfileResponse(
                uc.Company.Entity.Name,
                uc.Company.Entity.Identification,
                uc.Company.Entity.Type.ToString(),
                uc.CreatedDate
            )));

        return new AvailableProfileResponse(profiles, current);
    }

    public async Task SetActiveProfile(long? CompanyId)
    {
        var userCompanies = _repo.Query<UserCompany>().Where(x => x.UserId == UserId);

        foreach (var uc in userCompanies)
        {
            uc.IsActive = (CompanyId != null && uc.CompanyId == CompanyId);
        }
    }
}
