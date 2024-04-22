namespace CashFlow.Exception.ExceptionsBase;
public abstract class CashFlowException : SystemException
{
    protected CashFlowException(string message) : base(message)
    {
        
    }
}
