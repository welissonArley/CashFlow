using CashFlow.Application.UseCases.Expenses.GetById;
using CashFlow.Domain.Entities;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CommonTestUtilities.Entities;
using CommonTestUtilities.LoggedUser;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using FluentAssertions;

namespace UseCases.Test.Expenses.GetById;
public class GetExpenseByIdUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var loggedUser = UserBuilder.Build();
        var expense = ExpenseBuilder.Build(loggedUser);

        var useCase = CreateUseCase(loggedUser, expense);

        var result = await useCase.Execute(expense.Id);

        result.Should().NotBeNull();
        result.Id.Should().Be(expense.Id);
        result.Title.Should().Be(expense.Title);
        result.Description.Should().Be(expense.Description);
        result.Date.Should().Be(expense.Date);
        result.Amount.Should().Be(expense.Amount);
        result.PaymentType.Should().Be((CashFlow.Communication.Enums.PaymentType)expense.PaymentType);
        result.Tags.Should().NotBeNullOrEmpty().And.BeEquivalentTo(expense.Tags.Select(tag => tag.Value));
    }

    [Fact]
    public async Task Error_Expense_Not_Found()
    {
        var loggedUser = UserBuilder.Build();

        var useCase = CreateUseCase(loggedUser);

        var act = async () => await useCase.Execute(id: 1000);

        var result = await act.Should().ThrowAsync<NotFoundException>();

        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.EXPENSE_NOT_FOUND));
    }

    private GetExpenseByIdUseCase CreateUseCase(User user, Expense? expense = null)
    {
        var repository = new ExpensesReadOnlyRepositoryBuilder().GetById(user, expense).Build();
        var mapper = MapperBuilder.Build();
        var loggedUser = LoggedUserBuilder.Build(user);

        return new GetExpenseByIdUseCase(repository, mapper, loggedUser);
    }
}
