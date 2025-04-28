using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Requests;
using TemplateMarket.Application.UseCases.Orders.Dtos;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;
using TemplateMarket.Domain.Events.OrderItem;

namespace TemplateMarket.Application.UseCases.Orders.Commands.CreateOrder;

public class CreateOrderCommand : AuthCommand, IRequest<long>
{
    public List<TemplateOrderDto> Templates { get; init; } = [];
    public List<ServiceOrderDto> Services { get; init; } = [];
}

public class CreateOrderCommandHandler(
    IRepository<Customer> _customerRepo,
    IRepository<Template> _templateRepo,
    IRepository<Partner> _partnerRepo,
    IRepository<TemplateMarket.Domain.Entities.Service> _serviceRepo,
    IRepository<Order> _orderRepo,
    IMediator _mediator
) : IRequestHandler<CreateOrderCommand, long>
{
    public async Task<long> Handle(CreateOrderCommand request, CancellationToken ct)
    {
        // alterar para pegar da sessão, podendo ser CPF ou CNPJ
        var customer = await _customerRepo.SingleOrDefaultAsync(c => c.User.Id == request.UserId)
            ?? throw new NotFoundException(nameof(Customer), request.UserId);

        var order = new Order
        {
            CustomerId = customer.Id,
            OrderItems = []
        };

        // Adicionar templates
        foreach (var templateReq in request.Templates)
        {
            var template = await _templateRepo.GetByIdAsync(templateReq.TemplateId)
                ?? throw new NotFoundException(nameof(Template), templateReq.TemplateId);

            var templateOrderItem = new OrderItem(template.Id, template.Price);

            // Serviços atrelados ao template
            foreach (var serviceId in templateReq.AttachedServiceIds)
            {
                var service = await _serviceRepo.GetByIdAsync(serviceId)
                    ?? throw new NotFoundException(nameof(Service), serviceId);

                templateOrderItem.AddService(service.Id, service.Price);
            }

            order.OrderItems.Add(templateOrderItem);
        }

        // Adicionar serviços avulsos
        foreach (var serviceReq in request.Services)
        {
            var service = await _serviceRepo.GetByIdAsync(serviceReq.ServiceId)
                ?? throw new NotFoundException(nameof(Service), serviceReq.ServiceId);

            var serviceOrderItem = new OrderItem(service.Id, service.Price, true);

            order.OrderItems.Add(serviceOrderItem);
        }


        await _orderRepo.AddAsync(order);
        await _orderRepo.SaveChangesAsync();

        // Publicar eventos de criação de WorkOrders
        foreach (var orderItem in order.OrderItems)
        {
            await _mediator.Publish(new OrderItemCreatedDomainEvent(orderItem.Id));

            foreach (var serviceAttached in orderItem.Services)
            {
                await _mediator.Publish(new OrderItemServiceCreatedDomainEvent(serviceAttached.Id));
            }
        }

        return order.Id;
    }
}
