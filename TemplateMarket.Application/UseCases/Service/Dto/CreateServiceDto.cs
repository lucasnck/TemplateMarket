namespace TemplateMarket.Application.UseCases.Service.Dto
{
    public class CreateServiceDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
