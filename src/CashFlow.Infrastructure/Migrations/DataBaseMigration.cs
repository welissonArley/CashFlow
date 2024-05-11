using CashFlow.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure.Migrations;
public static class DataBaseMigration
{
    public async static Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<CashFlowDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}
