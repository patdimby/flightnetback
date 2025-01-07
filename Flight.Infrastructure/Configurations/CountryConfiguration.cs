using Flight.Domain.Entities;

namespace Flight.Flight.Infrastructure.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Entity<Country>().Navigation(e => e.City).AutoInclude();
    }
}