using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations;

public class UserGroupTemplateConfiguration : IEntityTypeConfiguration<UserGroupTemplate>
{
    public void Configure(EntityTypeBuilder<UserGroupTemplate> builder)
    {
        builder.HasKey(ugt => ugt.Id);

        builder.HasOne(ugt => ugt.Group)
            .WithMany()
            .HasForeignKey(ugt => ugt.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
