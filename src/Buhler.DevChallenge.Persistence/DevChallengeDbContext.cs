using Microsoft.EntityFrameworkCore;
using Buhler.DevChallenge.Domain.MobileFoodFacilities;
using Buhler.DevChallenge.Persistence.Configurations;

namespace Buhler.DevChallenge.Persistence;

public class DevChallengeDbContext : DbContext
{
    public DbSet<MobileFoodFacility> MobileFoodFacilities => Set<MobileFoodFacility>();
    
    public DevChallengeDbContext(DbContextOptions<DevChallengeDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new MobileFoodFacilityConfiguration());
    }
}