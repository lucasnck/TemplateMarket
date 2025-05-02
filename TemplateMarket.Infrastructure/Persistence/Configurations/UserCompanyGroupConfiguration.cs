using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations;

public class UserCompanyGroupConfiguration : IEntityTypeConfiguration<UserCompanyGroup>
{
    public void Configure(EntityTypeBuilder<UserCompanyGroup> builder)
    {
        builder.ToTable("UserCompanyGroups");
        builder.HasKey(ucg => ucg.Id);

        builder.HasOne(ucg => ucg.User)
            .WithMany(u => u.UserCompanyGroups)
            .HasForeignKey(ucg => ucg.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ucg => ucg.Company)
            .WithMany(c => c.UserCompanyGroups)
            .HasForeignKey(ucg => ucg.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ucg => ucg.Group)
            .WithMany()
            .HasForeignKey(ucg => ucg.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
