namespace Booking.SharedKernel.Contracts
{
    public interface IUserDto
    {
        int Id { get; set; }
        string Username { get; set; }
        string Email { get; set; }
        string FullName { get; set; }
        string Role { get; set; }
    }
}