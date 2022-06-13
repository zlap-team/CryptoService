namespace Application.DTOs.Account;

public class BaseUserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
}