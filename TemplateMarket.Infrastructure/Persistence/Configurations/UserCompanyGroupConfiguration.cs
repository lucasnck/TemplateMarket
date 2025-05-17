using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations;

public class UserCompanyGroupConfiguration : IEntityTypeConfiguration<UserCompanyGroup>
{
    public void Configure(EntityTypeBuilder<UserCompanyGroup> builder)
    {
        builder.HasKey(ucg => ucg.Id);

        builder.HasOne(ucg => ucg.UserCompany)
            .WithMany(u => u.UserCompanyGroups)
            .HasForeignKey(ucg => ucg.UserCompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ucg => ucg.Group)
            .WithMany()
            .HasForeignKey(ucg => ucg.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
