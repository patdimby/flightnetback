using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Flight.Domain.Entities;
using Flight.Domain.Interfaces;
using Flight.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Flight.Api.Controllers;

public class BookingsController : ParentController
{
    private readonly IGenericRepository<Booking> _bookingRepository;

    public BookingsController(IRepositoryManager manager) : base(manager)
    {
        _bookingRepository = Manager.Booking;
    }

    /// <summary>
    /// Gets all the bookings.
    /// </summary>
    /// <returns>List of all real bookings.</returns>
    [EndpointDescription("Display list of bookings.")]
    [ProducesResponseType(typeof(IEnumerable<Booking>), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    [EndpointName("bookings")]
    [EndpointSummary("All bookings")]
    public override async Task<IActionResult> GetAll()
    {
        var bookings = await _bookingRepository.AllAsync();

        return Ok(bookings);
    }

    /// <summary>
    /// Retrieve a specific booking's details by ID.
    /// </summary>
    /// <param name="id">The ID of the booking to retrieve.</param>
    /// <returns>The details of the requested booking.</returns>
    [HttpGet("{id:int}")]
    [EndpointName("GetBookingById")]
    [EndpointSummary("Get a booking by id")]
    [EndpointDescription("Fetch a booking by id or returns 404 if no booking with the ID exist.")]
    [ProducesResponseType(typeof(Booking), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    public async Task<ActionResult<Booking>> Get(int id)
    {
        var booking = await _bookingRepository.GetByIdAsync(id);
        if (booking == null) return NotFound();
        return Ok($"Booking found: {booking}");
    }

    /// <summary>
    /// Create a new booking.
    /// </summary>
    /// <param name="booking">The booking information for creation.</param>
    /// <returns>A confirmation of the booking successful creation.</returns>
    [HttpPost]
    [EndpointSummary("Create a booking")]
    [EndpointDescription("Create a booking or returns bad request.")]
    [ProducesResponseType(typeof(Booking), 200)]
    public async Task<ActionResult<Booking>> Create(BookingDto booking)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            await _bookingRepository.AddAsync(new Booking(booking));
        }
        catch (Exception e)
        {
            return BadRequest(e.InnerException);
        }

        return Ok($"Booking created successfully: {booking}");
    }

    [HttpPut]
    [EndpointSummary("Update a booking")]
    [EndpointDescription("Update booking or returns bad request.")]
    public async Task<ActionResult<Booking>> Put([FromBody] BookingDto booking)
    {
        Booking item;
        try
        {
            item = await _bookingRepository.GetByIdAsync(booking.Id);
            item.Copy(booking);
            await _bookingRepository.Update(item);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok($"Booking updated successfully: {item}");
    }

    [HttpDelete("{id:int}")]
    [EndpointSummary("Delete a booking")]
    [EndpointDescription("delete booking or returns bad request.")]
    public async Task<ActionResult<Booking>> Delete(int id)
    {
        var item = await _bookingRepository.GetByIdAsync(id);
        if (item is null) return NotFound();
        try
        {
            await _bookingRepository.DeleteAsync(id);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok($"Booking deleted successfully: {item}");
    }
}