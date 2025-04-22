namespace TemplateMarket.Application.UseCases.Category.Dtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Type { get; set; } = default!;
        public bool IsActive { get; set; } = true;
    }
}
