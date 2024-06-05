using CashFlow.Domain.Entities;

namespace WebApi.Test.Resources;
public class ExpenseIdentityManager
{
    private readonly Expense _expense;

    public ExpenseIdentityManager(Expense expense)
    {
        _expense = expense;
    }

    public long GetId() => _expense.Id;
    public DateTime GetDate() => _expense.Date;
}
