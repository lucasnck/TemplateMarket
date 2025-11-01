using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.UserCompanies.Queries;

public record GetUserCompaniesQuery() : IRequest<IQueryable<CompanyResponse>>;

public class GetUserCompaniesQueryHandler(
    IRepository _repo,
    IMapper _mapper,
    IActiveProfileService _activeProfileService
) : IRequestHandler<GetUserCompaniesQuery, IQueryable<CompanyResponse>>
{
    public async Task<IQueryable<CompanyResponse>> Handle(GetUserCompaniesQuery request, CancellationToken ct)
    {
        var query = _repo.Query<UserCompany>()
            .Include(uc => uc.Company)
            .Where(uc => uc.UserId == _activeProfileService.TryGetUserId())
            .Select(uc => uc.Company);

        return Task.FromResult(query);
    }   
}
