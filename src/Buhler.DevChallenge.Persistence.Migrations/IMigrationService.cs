namespace Buhler.DevChallenge.Persistence.Migrations;

public interface IMigrationService
{
    Task MigrateAsync(CancellationToken cancellationToken = default);
}
