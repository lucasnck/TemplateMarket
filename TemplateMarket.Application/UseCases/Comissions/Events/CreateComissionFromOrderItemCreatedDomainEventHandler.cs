using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Enums;
using TemplateMarket.Domain.Events.OrderItem;

namespace TemplateMarket.Application.UseCases.OrderItemServices.Events;

public class CreateComissionFromOrderItemDomainEventHandler(
    IRepository<OrderItem> _orderItemRepo,
    IRepository<Commission> _commissionRepo
) : INotificationHandler<OrderItemCreatedDomainEvent>
{
    public async Task Handle(OrderItemCreatedDomainEvent notification, CancellationToken ct)
    {
        var orderItem = await _orderItemRepo.GetByIdAsync(notification.Id)
            ?? throw new NotFoundException(nameof(OrderItem), notification.Id);
        
        if (orderItem.Product?.Partner == null)
            return;

        decimal percentualRepasse = GetPercentualRepasse(orderItem.Product.Partner?.Type);

        if (percentualRepasse == 0)
            return; // Partner sem direito a comissão

        var commission = new Commission()
        {
            Partner = orderItem.Product.Partner,
            SaleAmount = orderItem.UnitPrice,
            CommissionAmount = orderItem.UnitPrice * percentualRepasse,
            OrderItem = orderItem,
        };

        await _commissionRepo.AddAsync(commission);
        await _commissionRepo.SaveChangesAsync();
    }

    private decimal GetPercentualRepasse(PartnerType? partnerType)
    {
        return partnerType switch
        {
            PartnerType.Designer => 0.7m,
            PartnerType.Agency => 0.8m,
            _ => 0m
        };
    }
}
