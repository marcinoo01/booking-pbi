// === File: WebApi/Program.cs ===

using Booking.Application.Mappings;
using Booking.Domain.Interfaces;
using Booking.Infrastructure.Data;
using Booking.Infrastructure.UnitOfWork;
using Booking.Infrastructure.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AllowWasm",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:5005", "http://localhost:5006") // WASM ports
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
// Serilog configuration
builder.Host.UseSerilog((ctx, services, cfg) =>
LoggingConfiguration.Configure(cfg, ctx.Configuration));

// Database context
builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(o => o.AddPolicy("AllowAll", p =>
{
    p.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

// Domain & UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
c.SwaggerDoc("v1", new OpenApiInfo { Title = "Booking API", Version = "v1" });
});

var app = builder.Build();
app.UseCors("AllowAll");
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking API v1"));
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

