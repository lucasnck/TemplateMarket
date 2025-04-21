namespace TemplateMarket.Application.UseCases.Service.Dto
{
    public class UpdateServiceDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
