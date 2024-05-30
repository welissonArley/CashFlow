namespace CashFlow.Domain.Security.Tokens;
public interface ITokenProvider
{
    string TokenOnRequest();
}
