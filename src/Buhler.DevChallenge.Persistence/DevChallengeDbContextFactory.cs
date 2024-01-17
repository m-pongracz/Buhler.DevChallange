using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Buhler.DevChallenge.Domain.Settings;

namespace Buhler.DevChallenge.Persistence;

public class DevChallengeDbContextFactory : IDbContextFactory<DevChallengeDbContext>
{
    private readonly DbConnectionSettings _dbConnectionSettings;

    public DevChallengeDbContextFactory(IOptions<DbConnectionSettings> dbConnectionSettings)
    {
        _dbConnectionSettings = dbConnectionSettings.Value;
    }

    public DevChallengeDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<DevChallengeDbContext>();

        optionsBuilder
            .UseSqlServer(_dbConnectionSettings.ConnectionString,
                x =>
                {
                    x.MigrationsAssembly(MigrationConstants.MigrationAssembly);
                    x.UseNetTopologySuite();
                });

        return new DevChallengeDbContext(optionsBuilder.Options);
    }
}