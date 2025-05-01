using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Requests;
using TemplateMarket.Application.UseCases.Orders.Dtos;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Enums;
using TemplateMarket.Domain.Events;
using TemplateMarket.Domain.Events.OrderItem;

namespace TemplateMarket.Application.UseCases.Orders.Commands.CreateOrder;

public class CreateOrderCommand : AuthCommand, IRequest<long>
{
    public string Identification { get; set; }
    public List<ProductOrderDto> Products { get; init; } = [];
}

public class CreateOrderCommandHandler(
    IRepository<Customer> _customerRepo,
    IRepository<Product> _productRepo,
    IRepository<Order> _orderRepo,
    IMediator _mediator
) : IRequestHandler<CreateOrderCommand, long>
{
    public async Task<long> Handle(CreateOrderCommand request, CancellationToken ct)
    {
        var customer = await _customerRepo.SingleOrDefaultAsync(c => c.UserId == request.UserId)
            ?? throw new NotFoundException(nameof(Customer), request.UserId);

        var order = new Order
        {
            CustomerId = customer.Id,
            OrderItems = []
        };

        foreach (var item in request.Products)
        {
            var product = await _productRepo.GetByIdAsync(item.ProductId)
                ?? throw new NotFoundException(nameof(Product), item.ProductId);

            var orderItem = new OrderItem()
            {
                Order = order,
                Product = product,
            };

            foreach (var serviceId in item.AttachedServiceIds)
            {
                var service = await _productRepo.GetByIdAsync(serviceId)
                    ?? throw new NotFoundException("Service Product", serviceId);

                var serviceItem = new OrderItemService()
                {
                    OrderItem = orderItem,
                    Product = service
                };
                orderItem.OrderItemServices.Add(serviceItem);
            }

            order.OrderItems.Add(orderItem);
        }

        await _orderRepo.AddAsync(order);
        await _orderRepo.SaveChangesAsync();

        // Publicar eventos de domínio
        foreach (var orderItem in order.OrderItems)
        {
            if (orderItem.Product.ProductType == ProductType.Service)
                await _mediator.Publish(new OrderItemCreatedDomainEvent(orderItem.Id), ct);

            foreach (var service in orderItem.OrderItemServices)
                await _mediator.Publish(new OrderItemServiceCreatedDomainEvent(service.Id), ct);
        }

        return order.Id;
    }
}