using TemplateMarket.Application.UseCases.Entities.Dtos;

namespace TemplateMarket.Application.UseCases.Companies.Dtos;

public class CompanyDto
{
    public string Email { get; set; }
    public string Phone { get; set; }
    public EntityDto Entity { get; set; }
}