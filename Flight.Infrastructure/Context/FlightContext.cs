using Flight.Domain.Entities;
using Flight.Domain.Models;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;
using System.Reflection;

namespace Flight.Infrastructure.Context
{
    /// <summary>
    /// The flight context.
    /// </summary>
    public class FlightContext(DbContextOptions<FlightContext> options) : DbContext(options)
    {
        /// <summary>
        /// Gets or sets the airline.
        /// </summary>
        public DbSet<Airline> Airline { get; set; }

        /// <summary>
        /// Gets or sets the airport.
        /// </summary>
        public DbSet<Airport> Airport { get; set; }

        /// <summary>
        /// Gets or sets the flight.
        /// </summary>
        public DbSet<Domain.Models.Flight> Flight { get; set; }

        /// <summary>
        /// Gets or sets the passenger.
        /// </summary>
        public DbSet<Passenger> Passenger { get; set; }

        /// <summary>
        /// Gets or sets the reservation.
        /// </summary>
        public DbSet<Reservation> Reservation { get; set; }

        /// <summary>
        /// Gets or sets the vehicle.
        /// </summary>
        public DbSet<Vehicle> Vehicle { get; set; }

        /// <summary>
        /// Begins the transaction.
        /// </summary>

        /// <summary>
        /// Ons the model creating.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            if (Database.ProviderName == "Microsoft.EntityFramework.Sqlite")
            {
                foreach (var entity in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entity.ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(decimal));
                    var dateandtimepropertise = entity.ClrType.GetProperties()
                        .Where(t => t.PropertyType == typeof(DateTimeOffset));
                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entity.Name).Property(property.Name)
                            .HasConversion<double>();
                    }
                    foreach (var property in dateandtimepropertise)
                    {
                        modelBuilder.Entity(entity.Name).Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter());
                    }
                }
            }
        }
    }
}