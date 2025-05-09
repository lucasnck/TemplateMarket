using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string Phone { get; set; }
    public string PasswordHash { get; set; }
    //public string Role { get; set; } // "Admin", "Customer", "Partner"

    public string? ResetToken { get; set; }
    public DateTime? ResetTokenExpiresAt { get; set; }

    public string? EmailVerificationToken { get; set; }
    public DateTime? EmailVerificationTokenExpiresAt { get; set; }
    public bool IsEmailVerified { get; set; } = false;

    public long EntityId { get; set; }
    public virtual Entity Entity { get; set; }
    public virtual ICollection<UserGroup> UserGroups { get; set; }
    public virtual ICollection<UserCompanyGroup> UserCompanyGroups { get; set; }
}