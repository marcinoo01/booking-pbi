using Booking.Domain.Interfaces;
using Booking.Infrastructure.Logging;
using Booking.Infrastructure.UnitOfWork;
using MudBlazor.Services;
using Serilog;

var serverBuilder = WebApplication.CreateBuilder(args);

// Serilog configuration
serverBuilder.Host.UseSerilog((ctx, services, cfg) =>
    LoggingConfiguration.Configure(cfg, ctx.Configuration));

// UI services
serverBuilder.Services.AddMudServices();
serverBuilder.Services.AddRazorPages();
serverBuilder.Services.AddServerSideBlazor();

// Domain & UnitOfWork
serverBuilder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var serverApp = serverBuilder.Build();

if (!serverApp.Environment.IsDevelopment())
{
    serverApp.UseExceptionHandler("/Error");
    serverApp.UseHsts();
}

serverApp.UseHttpsRedirection();
serverApp.UseStaticFiles();
serverApp.UseRouting();

serverApp.MapBlazorHub();
serverApp.MapFallbackToPage("/_Host");
serverApp.Run();