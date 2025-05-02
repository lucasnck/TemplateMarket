using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations;

public class GroupRoleConfiguration : IEntityTypeConfiguration<GroupRole>
{
    public void Configure(EntityTypeBuilder<GroupRole> builder)
    {
        builder.ToTable("GroupRoles");
        builder.HasKey(gr => gr.Id);

        builder.HasOne(gr => gr.Group)
            .WithMany(g => g.GroupRoles)
            .HasForeignKey(gr => gr.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(gr => gr.Role)
            .WithMany(r => r.GroupRoles)
            .HasForeignKey(gr => gr.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}