using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Application.Common.Models;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.UserCompanies.Queries;

public record GetUserCompaniesQuery(SieveModel SieveModel) : IRequest<PaginatedResult<CompanyResponse>>;

public class GetUserCompaniesQueryHandler(
    IRepository _repo,
    IMapper _mapper,
    ISieveProcessor _sieve,
    IActiveProfileService _activeProfileService
) : IRequestHandler<GetUserCompaniesQuery, PaginatedResult<CompanyResponse>>
{
    public async Task<PaginatedResult<CompanyResponse>> Handle(GetUserCompaniesQuery request, CancellationToken ct)
    {
        var query = _repo.Query<UserCompany>()
            .Include(uc => uc.Company)
            .Where(uc => uc.UserId == _activeProfileService.TryGetUserId())
            .Select(uc => uc.Company);

        return await query.ToPaginatedResultAsync<Company, CompanyResponse>(_sieve, _mapper, request.SieveModel, ct);
    }   
}
