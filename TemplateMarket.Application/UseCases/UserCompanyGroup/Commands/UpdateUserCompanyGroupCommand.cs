using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.UserCompanyGroup.Dtos;
using TemplateMarket.Domain.Entities;


namespace TemplateMarket.Application.UseCases.UserCompanyGroup.Commands;

public class UpdateUserCompanyGroupCommand : UpdateUserCompanyGroupDto, IRequest<IEnumerable<UserCompanyGroupResponse>>
{
}

public class UpdateUserCompanyGroupCommandHandler(
    IRepository _repo,
    IMapper _mapper
) : IRequestHandler<UpdateUserCompanyGroupCommand, IEnumerable<UserCompanyGroupResponse>>
{
    public async Task<IEnumerable<UserCompanyGroupResponse>> Handle(UpdateUserCompanyGroupCommand request, CancellationToken cancellationToken)
    {
        var user = await _repo.SingleOrThrow<User>(u => u.Id == request.UserId);
        var userCompany = user.UserCompanyGroups
            .FirstOrDefault(ucg => ucg.UserCompany.CompanyId == request.CompanyId)?
            .UserCompany;

        if (userCompany == null) throw new NotFoundException(nameof(UserCompany));

        var groups = _repo.Query<Group>().Where(g => request.GroupIds.Contains(g.Id));

        var currentGroupIds = user.UserCompanyGroups?
            .Where(ucg => ucg.UserCompany.CompanyId == request.CompanyId)
            .Select(ucg => ucg.GroupId) ?? [];

        var groupsToAdd = groups
            .Where(g => !currentGroupIds.Contains(g.Id))
            .ToList();

        foreach (var group in groupsToAdd)
        {
            var userCompanyGroup = new TemplateMarket.Domain.Entities.UserCompanyGroup()
            {
                Group = group,
                UserCompany = userCompany,
            };

            await _repo.AddAsync(userCompanyGroup);
        }

        var userCompanyGroupsToRemove = user.UserCompanyGroups?
            .Where(ug => !request.GroupIds.Contains(ug.GroupId))
            .ToList() ?? [];

        foreach (var userCompanyGroups in userCompanyGroupsToRemove)
        {
            _repo.Remove(userCompanyGroups);
        }

        await _repo.UpdateAsync(user);
        await _repo.SaveChangesAsync();

        return _mapper.Map<IEnumerable<UserCompanyGroupResponse>>(user.UserCompanyGroups);
    }
}
