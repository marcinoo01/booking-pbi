using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<User> Users => Set<User>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<AppointmentSlot> AppointmentSlots => Set<AppointmentSlot>();
    public DbSet<Reservation> Reservations => Set<Reservation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(200);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.FullName).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Role).IsRequired().HasMaxLength(50);
        });

        modelBuilder.Entity<Service>(builder =>
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(150);
            builder.Property(s => s.Description).HasMaxLength(1000);
            builder.Property(s => s.DurationMinutes).IsRequired();
        });

        modelBuilder.Entity<AppointmentSlot>(builder =>
        {
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.Service)
                .WithMany()
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(a => a.StartTime).IsRequired();
            builder.Property(a => a.EndTime).IsRequired();
            builder.Property(a => a.IsReserved).IsRequired();
        });

        modelBuilder.Entity<Reservation>(builder =>
        {
            builder.HasKey(r => r.Id);
            builder.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);
            builder.HasOne(r => r.Service)
                .WithMany()
                .HasForeignKey(r => r.ServiceId);
            builder.HasOne(r => r.AppointmentSlot)
                .WithMany()
                .HasForeignKey(r => r.AppointmentSlotId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(r => r.ReservedAt).IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}