using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Domain.Interfaces;

public interface ITemplateRepository
{
    Task<Template?> GetByIdAsync(long id);
    Task<IEnumerable<Template>> GetAllAsync();
    Task AddAsync(Template template);
    Task UpdateAsync(Template template);
    Task DeleteAsync(long id);
}
