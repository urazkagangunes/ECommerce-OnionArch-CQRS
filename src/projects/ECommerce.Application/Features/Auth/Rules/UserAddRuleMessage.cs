namespace ECommerce.Application.Features.Auth.Rules;

public class UserAddRuleMessage
{
    public string UserNameMinCharacterMessage { get; set; } = default!;
    public string PasswordMinCharacterMessage { get; set; } = default!;
}