using Microsoft.EntityFrameworkCore;
using Buhler.DevChallenge.Persistence;

namespace Buhler.DevChallenge.Persistence.Migrations;

public class MigrationService : IMigrationService
{
    private readonly DevChallengeDbContext _dbContext;

    public MigrationService(DevChallengeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task MigrateAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.Database.MigrateAsync(cancellationToken);
    }
}
