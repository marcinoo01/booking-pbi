// SlotsController.cs - placeholder file

using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebApi.Controllers;

[ApiController]
[Route("api/slots")]
public class SlotsController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    public SlotsController(IUnitOfWork uow) => _uow = uow;

    
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _uow.AppointmentSlots.GetAllAsync());

    [HttpGet("available/{serviceId}")]
    public async Task<IActionResult> Available(int serviceId)
    {
        var repo = (ISlotRepository)_uow.AppointmentSlots;
        var list = await repo.GetAvailableSlotsAsync(serviceId, DateTime.UtcNow);
        return Ok(list);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AppointmentSlot entity)
    {
        await _uow.AppointmentSlots.AddAsync(entity);
        await _uow.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = entity.Id }, entity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _uow.AppointmentSlots.GetByIdAsync(id);
        if (existing is null) return NotFound();
        _uow.AppointmentSlots.Delete(existing);
        await _uow.SaveChangesAsync();
        return NoContent();
    }
}