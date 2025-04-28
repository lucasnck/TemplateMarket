using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.WorkOrders.Events;

public class OrderItemServiceCreatedDomainEventHandler(
    IRepository<WorkOrder> _workOrderRepo,
    IRepository<OrderItemService> _orderItemServiceRepo
) : INotificationHandler<OrderItemServiceCreatedDomainEvent>
{
    public async Task Handle(OrderItemServiceCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var orderItemservice = await _orderItemServiceRepo.GetByIdAsync(notification.Id)
            ?? throw new NotFoundException(nameof(OrderItem), notification.Id);

        var workOrder = new WorkOrder();
        workOrder.AssignedToPartner = orderItemservice.Partner;
        workOrder.OrderItemService = orderItemservice;

        await _workOrderRepo.AddAsync(workOrder);
        await _workOrderRepo.SaveChangesAsync();
    }
}
