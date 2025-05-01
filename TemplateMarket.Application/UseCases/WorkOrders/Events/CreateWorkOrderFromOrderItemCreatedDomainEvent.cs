using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Enums;
using TemplateMarket.Domain.Events.OrderItem;

namespace TemplateMarket.Application.OrderItems.EventHandlers;

public class CreateWorkOrderFromOrderItemCreatedDomainEventHandler(
    IRepository<WorkOrder> _workOrderRepo,
    IRepository<OrderItem> _orderItemRepo
) : INotificationHandler<OrderItemCreatedDomainEvent>
{
    public async Task Handle(OrderItemCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var orderItem = (await _orderItemRepo.FindAsync(ois => ois.Id == notification.Id)).First();

        if (orderItem != null)
        {
            var workOrder = new WorkOrder()
            {
                OrderItem = orderItem,
                Status = WorkOrderStatus.Pending,
            };

            await _workOrderRepo.AddAsync(workOrder);
            await _workOrderRepo.SaveChangesAsync();
        }
    }
}
