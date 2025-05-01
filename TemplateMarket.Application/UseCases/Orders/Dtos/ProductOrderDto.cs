namespace TemplateMarket.Application.UseCases.Orders.Dtos;

public record ProductOrderDto(
    long ProductId,
    List<long> AttachedServiceIds // serviços atrelados a esse template
);