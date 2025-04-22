namespace TemplateMarket.Application.UseCases.Category.Dtos
{
    public class UpdateCategoryDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public bool? IsActive { get; set; }
    }
}
