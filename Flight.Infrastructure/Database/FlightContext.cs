using System;
using System.Linq;
using System.Reflection;
using Flight.Domain.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flight.Infrastructure.Data;

/// <summary>
///     The flight context.
/// </summary>
public class FlightContext : DbContext
{
    /// <summary>
    ///     Gets or sets the airline.
    /// </summary>
    public DbSet<Airline> Airline { get; set; }

    /// <summary>
    ///     Gets or sets the airport.
    /// </summary>
    public DbSet<Airport> Airport { get; set; }

    /// <summary>
    ///     Gets or sets the flight.
    /// </summary>
    public DbSet<Domain.Entities.Flight> Flight { get; set; }

    /// <summary>
    ///     Gets or sets the passenger.
    /// </summary>
    public DbSet<Passenger> Passenger { get; set; }

    /// <summary>
    ///     Gets or sets the reservation.
    /// </summary>
    public DbSet<Booking> Booking { get; init; }

    /// <summary>
    ///     Gets or sets the vehicle.
    /// </summary>
    public DbSet<Vehicle> Vehicle { get; set; }

    /// <summary>
    ///     Gets or sets the country.
    /// </summary>
    public DbSet<Country> Country { get; set; }

    /// <summary>
    ///     Gets or sets the city.
    /// </summary>
    public DbSet<City> City { get; set; }

    /// <summary>
    ///     Ons the configuring.
    /// </summary>
    /// <param name="optionsBuilder">The options builder.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connString = "server=127.0.0.1;port=3306;user=root;password=Ma$terkey1;database=flights";
        optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString));
    }

    /// <summary>
    ///     Begins the transaction.
    /// </summary>
    /// <summary>
    ///     Ons the model creating.
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //
    }
}