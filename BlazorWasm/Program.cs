using Booking.BlazorWasm;
using Booking.BlazorWasm.Services;
using MudBlazor.Services;
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient {
    BaseAddress = new Uri("https://localhost:5001/") 
});

builder.RootComponents.Add<App>("#app");
builder.Services.AddMudServices();
builder.Services.AddScoped<ServicesApiClient>();
builder.Services.AddScoped<ReservationsApiClient>();

await builder.Build().RunAsync();
