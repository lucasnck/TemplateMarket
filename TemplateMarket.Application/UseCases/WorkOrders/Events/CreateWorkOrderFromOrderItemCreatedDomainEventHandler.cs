using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Enums;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.OrderItems.EventHandlers;

public class CreateWorkOrderFromOrderItemCreatedDomainEventHandler(
    IRepository _repo
) : INotificationHandler<OrderItemCreatedDomainEvent>
{
    public async Task Handle(OrderItemCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var orderItem = (await _repo.SingleOrThrow<OrderItem>(ois => ois.Id == notification.Id));

        var workOrder = new WorkOrder()
        {
            OrderItem = orderItem,
            Status = WorkOrderStatus.Pending,
        };

        await _repo.AddAsync(workOrder);
        await _repo.SaveChangesAsync();
    }
}
