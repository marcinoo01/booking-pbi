# Booking System

> Aplikacja do rezerwacji wizyt – projekt zaliczeniowy z Programowania Aplikacji Biznesowych

---

## Spis treści

1. Opis i zawartość projektu  
2. Wymagania  
3. Instalacja i uruchomienie  
4. Dostępne endpointy i strony UI  
5. Obrazy statyczne  
6. Logger Serilog  
7. Skład zespołu  

---

## Opis i zawartość projektu

Aplikacja Booking System pozwala na:
- zarządzanie katalogiem usług (CRUD),
- przeglądanie szczegółów wybranej usługi,
- dodawanie nowych usług,
- (opcjonalnie) rezerwowanie terminów.
- dodano także swagger z którego można uruchamiać każdy z dostępnych restów po stronie webapi.
- Loggery które tworzą się przy starcie dla każdego dnia
  
Realizacja według czystej architektury:

Struktura folderów:
Booking.sln  
├── Booking.Domain         (encje i interfejsy IRepository, IUnitOfWork)  
├── Booking.Application    (DTO, AutoMapper, logika aplikacyjna)  
├── Booking.Infrastructure (EF Core/SQLite, repozytoria, migracje)  
├── Booking.SharedKernel   (wspólne modele i DTO)  
├── Booking.WebApi         (ASP.NET Core WebAPI + Serilog)  
├── Booking.BlazorServer   (Blazor Server + MudBlazor + Serilog)  
└── Booking.BlazorWasm     (Blazor WebAssembly + MudBlazor)

---

## Wymagania

- .NET 6.0 SDK  
- dotnet-ef (narzędzie EF Core CLI)  
- (opcjonalnie) IDE: Visual Studio, Rider lub VS Code  

---

## Instalacja i uruchomienie

1. Przywrócenie pakietów  
cd Booking  
dotnet restore

2. Migracje i stworzenie bazy SQLite  
dotnet ef migrations add InitialCreate --project Infrastructure/Infrastructure.csproj --startup-project WebApi/WebApi.csproj --output-dir Data/Migrations  
dotnet ef database update --project Infrastructure/Infrastructure.csproj --startup-project WebApi/WebApi.csproj

Po wykonaniu w folderze WebApi/bin/Debug/net6.0/ pojawi się plik booking.db

3. Uruchomienie WebAPI  
cd WebApi  
dotnet run  
https://localhost:5001/swagger

4. Uruchomienie Blazor Server  
cd ../BlazorServer  
dotnet run  
https://localhost:5010/

5. Uruchomienie Blazor WebAssembly  
cd ../BlazorWasm  
dotnet run  
http://localhost:5005/

---

## Dostępne endpointy i strony UI

### WebAPI  
- GET /api/services  
- GET /api/services/{id}  
- POST /api/services  
- (CRUD Reservations)

### UI (Blazor Server i WASM)  
- /services  
- /servicedetails/{id}  
- /createservice  
- /gallery  

---

## Obrazy statyczne

W katalogu wwwroot/images/ (w BlazorServer i BlazorWasm):
- 174-200x300.jpg  
- 17-200x300.jpg  
- 345-200x300.jpg  

Wyświetlane w komponentach MudCard i listach usług.

---

## Logger Serilog

### WebAPI  
Logi dzielone na:
- Logs/log-YYYYMMDD.txt — informacje
- Logs/error-YYYYMMDD.txt — błędy

Konfiguracja w Program.cs:  
builder.Host.UseSerilog((ctx, svc, cfg) => LoggingConfiguration.Configure(cfg, ctx.Configuration));

Analogicznie skonfigurowane w BlazorServer.

---

## Skład zespołu

- Marcin Mistela 
- Kamil Kućma
- Łukasz Pyrek

---
