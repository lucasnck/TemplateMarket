public interface IAuthCommand
{
    long UserId { get; set; }
    string? Role { get; set; }
    string? Email { get; set; }
}
