using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Application.UseCases.UserCompanies.Dtos;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events.OrderItem;

namespace TemplateMarket.Application.UseCases.UserCompanies.Commands;

public class CreateUserCompanyOwnerCommand : CreateUserCompanyOwnerDto, IRequest<long>
{
}   

public class CreateUserCompanyCommandHandler(
    IRepository _repo,
    IActiveProfileService _activeProfileService
) : IRequestHandler<CreateUserCompanyOwnerCommand, long>
{
    public async Task<long> Handle(CreateUserCompanyOwnerCommand request, CancellationToken cancellationToken)
    {
        var alreadyExists = _repo.Query<UserCompany>()
            .Any(uc => uc.Company.Entity.Identification == request.Identification);

        if (alreadyExists)
            throw new AlreadyExistsException(nameof(UserCompany));

        var user = await _activeProfileService.GetUser();
        var entity = ResolveEntity(request);
        var company = ResolveCompany(request, entity, user);
        var userCompany = ResolveUserCompany(company, user);

        userCompany.AddDomainEvent(new UserCompanyOwnerCreatedDomainEvent(userCompany));


        await _repo.SaveChangesAsync();


        return entity.Id;
    }

    private UserCompany ResolveUserCompany(Company company, User user)
    {
        var userCompany = new UserCompany()
        {
            IsActive = true,
            Company = company,
            User = user
        };

        _repo.AddAsync(userCompany);

        return userCompany;
    }

    private Company ResolveCompany(CreateUserCompanyOwnerCommand request, Entity entity, User user)
    {
        var company = new Company()
        {
            Owner = user,
            Email = request.Email,
            Phone = request.Phone,
            Entity = entity
        };

        _repo.AddAsync(company);

        return company;
    }

    private Entity ResolveEntity(CreateUserCompanyOwnerCommand request)
    {
        var entity = new Entity()
        {
            Name = request.Name,
            Identification = request.Identification,
            Type = Domain.Enums.EntityType.Company,
        };

        _repo.AddAsync(entity);

        return entity;
    }
}