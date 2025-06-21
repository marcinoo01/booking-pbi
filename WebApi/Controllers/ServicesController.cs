using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebApi.Controllers;

[ApiController]
[Route("api/services")]
public class ServicesController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    public ServicesController(IUnitOfWork uow) => _uow = uow;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _uow.Services.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var entity = await _uow.Services.GetByIdAsync(id);
        if (entity is null) return NotFound();
        return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Service entity)
    {
        await _uow.Services.AddAsync(entity);
        await _uow.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Service entity)
    {
        var existing = await _uow.Services.GetByIdAsync(id);
        if (existing is null) return NotFound();
        existing.UpdateDetails(entity.Name, entity.Description, entity.DurationMinutes);
        _uow.Services.Update(existing);
        await _uow.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _uow.Services.GetByIdAsync(id);
        if (existing is null) return NotFound();
        _uow.Services.Delete(existing);
        await _uow.SaveChangesAsync();
        return NoContent();
    }
}