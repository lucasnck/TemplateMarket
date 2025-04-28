using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Enums;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.OrderItemServices.Events;

public class CreateComissionFromOrderItemServiceCreatedDomainEventHandler(
    IRepository<OrderItemService> _orderItemServiceRepo,
    IRepository<Partner> _partnerRepo,
    IRepository<Commission> _commissionRepo
) : INotificationHandler<OrderItemServiceCreatedDomainEvent>
{
    public async Task Handle(OrderItemServiceCreatedDomainEvent notification, CancellationToken ct)
    {
        var orderItemService = await _orderItemServiceRepo.GetByIdAsync(notification.Id)
            ?? throw new NotFoundException(nameof(OrderItemService), notification.Id);

        decimal percentualRepasse = GetPercentualRepasse(orderItemService.Partner.Type);

        if (percentualRepasse == 0)
            return; // Partner sem direito a comissão

        var commission = new Commission()
        {
            Partner = orderItemService.Partner,
            SaleAmount = orderItemService.UnitPrice,
            CommissionAmount = orderItemService.UnitPrice * percentualRepasse,
            OrderItemService = orderItemService,
        };

        await _commissionRepo.AddAsync(commission);
        await _commissionRepo.SaveChangesAsync();
    }

    private decimal GetPercentualRepasse(PartnerType partnerType)
    {
        return partnerType switch
        {
            PartnerType.Designer => 0.7m,
            PartnerType.Agency => 0.8m,
            _ => 0m
        };
    }
}
