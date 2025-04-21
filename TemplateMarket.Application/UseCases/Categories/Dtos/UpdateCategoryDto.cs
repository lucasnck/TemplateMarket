namespace TemplateMarket.Application.UseCases.Category.Dtos
{
    public class UpdateCategoryDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsActive { get; set; } = true;
    }
}
