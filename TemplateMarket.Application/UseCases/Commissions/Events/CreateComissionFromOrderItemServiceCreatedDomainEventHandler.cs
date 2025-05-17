using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Enums;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.OrderItemServices.Events;

public class CreateComissionFromOrderItemServiceCreatedDomainEventHandler(
    IRepository _repo
) : INotificationHandler<OrderItemServiceCreatedDomainEvent>
{
    public async Task Handle(OrderItemServiceCreatedDomainEvent notification, CancellationToken ct)
    {
        var orderItemService = await _repo.SingleOrThrow<OrderItemService>(x => x.Id == notification.Id);

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

        await _repo.AddAsync(commission);
        await _repo.SaveChangesAsync();
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
