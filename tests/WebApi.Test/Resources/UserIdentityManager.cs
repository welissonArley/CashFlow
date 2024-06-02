using CashFlow.Domain.Entities;

namespace WebApi.Test.Resources;
public class UserIdentityManager
{
    private readonly User _user;
    private readonly string _password;
    private readonly string _token;

    public UserIdentityManager(User user, string password, string token)
    {
        _user = user;
        _password = password;
        _token = token;
    }

    public string GetName() => _user.Name;
    public string GetEmail() => _user.Email;
    public string GetPassword() => _password;
    public string GetToken() => _token;
}
