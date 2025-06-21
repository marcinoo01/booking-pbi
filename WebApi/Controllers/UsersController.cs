
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    public UsersController(IUnitOfWork uow) => _uow = uow;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _uow.Users.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var entity = await _uow.Users.GetByIdAsync(id);
        if (entity is null) return NotFound();
        return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Create(User entity)
    {
        await _uow.Users.AddAsync(entity);
        await _uow.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, User entity)
    {
        var existing = await _uow.Users.GetByIdAsync(id);
        if (existing is null) return NotFound();
        existing.UpdateProfile(entity.FullName, entity.Email);
        _uow.Users.Update(existing);
        await _uow.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _uow.Users.GetByIdAsync(id);
        if (existing is null) return NotFound();
        _uow.Users.Delete(existing);
        await _uow.SaveChangesAsync();
        return NoContent();
    }
}