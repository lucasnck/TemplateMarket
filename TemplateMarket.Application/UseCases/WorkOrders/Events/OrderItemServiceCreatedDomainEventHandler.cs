using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Enums;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.WorkOrders.Events;

public class OrderItemServiceCreatedDomainEventHandler(
    IRepository<WorkOrder> _workOrderRepo,
    IRepository<OrderItemService> _orderItemServiceRepo
) : INotificationHandler<OrderItemServiceCreatedDomainEvent>
{
    public async Task Handle(OrderItemServiceCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var orderItemService = (await _orderItemServiceRepo.FindAsync(ois => ois.Id == notification.Id)).First();

        if (orderItemService != null)
        {
            var workOrder = new WorkOrder()
            {
                OrderItemService = orderItemService,
                Status = WorkOrderStatus.Pending,
            };

            await _workOrderRepo.AddAsync(workOrder);
            await _workOrderRepo.SaveChangesAsync();
        }
    }
}
