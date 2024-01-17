using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Buhler.DevChallenge.Domain.MobileFoodFacilities;

namespace Buhler.DevChallenge.Persistence.Configurations;

public class MobileFoodFacilityConfiguration : IEntityTypeConfiguration<MobileFoodFacility>
{
    public void Configure(EntityTypeBuilder<MobileFoodFacility> builder)
    {
        builder.HasKey(x => x.LocationId);
        builder.Property(x => x.LocationId).ValueGeneratedNever();
    }
}