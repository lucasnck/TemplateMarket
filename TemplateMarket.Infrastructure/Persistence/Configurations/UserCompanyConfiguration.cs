using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations;

public class UserCompanyConfiguration : IEntityTypeConfiguration<UserCompany>
{
    public void Configure(EntityTypeBuilder<UserCompany> builder)
    {
        builder.HasKey(uc => uc.Id);

        builder.HasOne(ucg => ucg.User)
            .WithOne()
            .HasForeignKey<UserCompany>(uc => uc.UserId);


        builder.HasOne(ucg => ucg.Company)
            .WithOne()
            .HasForeignKey<UserCompany>(uc => uc.CompanyId);
    }
}