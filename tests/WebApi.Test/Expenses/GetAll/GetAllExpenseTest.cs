using FluentAssertions;
using System.Net;
using System.Text.Json;

namespace WebApi.Test.Expenses.GetAll;
public class GetAllExpenseTest : CashFlowClassFixture
{
    private const string METHOD = "api/Expenses";

    private readonly string _token;

    public GetAllExpenseTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _token = webApplicationFactory.User_Team_Member.GetToken();
    }

    [Fact]
    public async Task Success()
    {
        var result = await DoGet(requestUri: METHOD, token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.OK);

        var body = await result.Content.ReadAsStreamAsync();

        var response = await JsonDocument.ParseAsync(body);

        response.RootElement.GetProperty("expenses").EnumerateArray().Should().NotBeNullOrEmpty();
    }
}
