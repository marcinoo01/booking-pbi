
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Booking.SharedKernel.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebApi.Controllers;

[ApiController]
[Route("api/reservations")]
public class ReservationsController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    public ReservationsController(IUnitOfWork uow) => _uow = uow;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _uow.Reservations.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var entity = await _uow.Reservations.GetByIdAsync(id);
        if (entity is null) return NotFound();
        return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateReservationRequest req)
    {
        var reservation = new Reservation(req.UserId, req.ServiceId, req.AppointmentSlotId);
        await _uow.Reservations.AddAsync(reservation);
        var slot = await _uow.AppointmentSlots.GetByIdAsync(req.AppointmentSlotId);
        if (slot != null) slot.MarkReserved();
        await _uow.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = reservation.Id }, reservation);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> ByUser(int userId)
    {
        var repo = (IReservationRepository)_uow.Reservations;
        return Ok(await repo.GetByUserAsync(userId));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _uow.Reservations.GetByIdAsync(id);
        if (existing is null) return NotFound();
        var slot = await _uow.AppointmentSlots.GetByIdAsync(existing.AppointmentSlotId);
        if (slot != null) slot.MarkAvailable();
        _uow.Reservations.Delete(existing);
        await _uow.SaveChangesAsync();
        return NoContent();
    }      
        
}