namespace TemplateMarket.Application.UseCases.Orders.Dtos;

public record TemplateOrderDto(
    long TemplateId,
    List<long> AttachedServiceIds // serviços atrelados a esse template
);