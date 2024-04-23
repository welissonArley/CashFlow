namespace CashFlow.Exception.ExceptionsBase;
public abstract class CashFlowException : SystemException
{
    protected CashFlowException(string message) : base(message)
    {
        
    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
