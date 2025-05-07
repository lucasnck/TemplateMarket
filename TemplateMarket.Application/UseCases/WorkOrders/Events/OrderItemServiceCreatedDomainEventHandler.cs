using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Enums;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.WorkOrders.Events;

public class OrderItemServiceCreatedDomainEventHandler(
    IRepository _repo
) : INotificationHandler<OrderItemServiceCreatedDomainEvent>
{
    public async Task Handle(OrderItemServiceCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var orderItemService = await _repo.SingleOrThrow<OrderItemService>(ois => ois.Id == notification.Id);

        var workOrder = new WorkOrder()
        {
            OrderItemService = orderItemService,
            Status = WorkOrderStatus.Pending,
        };

        await _repo.AddAsync(workOrder);
        await _repo.SaveChangesAsync();
    }
}
