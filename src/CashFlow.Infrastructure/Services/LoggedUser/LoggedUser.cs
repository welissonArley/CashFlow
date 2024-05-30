using CashFlow.Domain.Entities;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CashFlow.Infrastructure.Services.LoggedUser;
internal class LoggedUser : ILoggedUser
{
    private readonly CashFlowDbContext _dbContext;

    public LoggedUser(CashFlowDbContext dbContext) => _dbContext = dbContext;

    public async Task<User> Get()
    {
        string token = "token";

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

        return await _dbContext
            .Users
            .AsNoTracking()
            .FirstAsync(user => user.UserIdentifier == Guid.Parse(identifier));
    }
}
