
namespace Booking.Domain.Entities;

public class Service
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public int DurationMinutes { get; private set; }

    protected Service() { }

    public Service(string name, string description, int durationMinutes)
    {
        Name = name;
        Description = description;
        DurationMinutes = durationMinutes;
    }

    public void UpdateDetails(string name, string description, int durationMinutes)
    {
        Name = name;
        Description = description;
        DurationMinutes = durationMinutes;
    }
}