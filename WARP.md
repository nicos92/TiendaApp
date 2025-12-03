# WARP.md

This file provides guidance to WARP (warp.dev) when working with code in this repository.

## Project Overview

TiendaApp is a WPF desktop application built with .NET 9.0 for managing a store (users, articles, sales). It uses a layered architecture with dependency injection and SQLite database storage.

## Architecture

### Layered Design

The application follows a clean architecture with clear dependency flows:

```
Login (Entry Point)
  ↓ references
UI ← Login
  ↓ references
Servicio
  ↓ references
Repositorio
  ↓ references
Modelo, Contrato
```

**Critical architectural rules:**
- **Login** is the startup project and application entry point (not UI)
- **Login** configures dependency injection and references all other projects
- **UI** never references Login to avoid circular dependencies
- **Contrato** defines interfaces; implementations live in Servicio/Repositorio
- **Utilidad** is independent and can be referenced by any layer

### Project Structure

- `src/TiendaApp.Login` - WPF entry point, configures DI container, registers services
- `src/TiendaApp.UI` - WPF windows and UI components
- `src/TiendaApp.Servicio` - Business logic layer
- `src/TiendaApp.Repositorio` - Data access layer (Dapper + SQLite)
- `src/TiendaApp.Modelo` - Domain models/entities
- `src/TiendaApp.Contrato` - Service and repository interfaces
- `src/TiendaApp.Utilidad` - Utilities (e.g., PasswordHasher using PBKDF2)
- `tests/TiendaApp.Test` - XUnit tests

### Dependency Injection

DI is configured in `TiendaApp.Login/App.xaml.cs` using `Microsoft.Extensions.DependencyInjection` and `Microsoft.Extensions.Hosting`. The `App` class:
1. Builds an `IHost` with services registered in `ConfigureServices`
2. Resolves `DatabaseInitializer` on startup to initialize SQLite database
3. Resolves and shows the `LoginWindow` as the first window

Windows and services must be registered in the DI container to be resolved.

### Database

- **Type**: SQLite (System.Data.SQLite + Microsoft.Data.Sqlite.Core)
- **Location**: `%LocalAppData%\TiendaApp\tienda.db` (see `PathHelper.cs`)
- **Schema**: Defined in `SchemaSql.cs` (Usuarios, Roles, UsuariosRoles, Articulos, Ventas, VentaDetalle)
- **Initialization**: Automatic on app startup via `DatabaseInitializer.Initialize()`
- **ORM**: Dapper for queries

**Default users** (password = username):
- superadmin → superadministrador role
- admin → administrador role
- gerente → gerente role
- supervisor → supervisor role
- encargado → encargado role
- empleado → empleado role

Passwords are hashed with PBKDF2 (100k iterations, SHA256) via `TiendaApp.Utilidad.PasswordHasher`.

## Common Commands

### Build
```powershell
dotnet build
```

### Run Application
```powershell
dotnet run --project src/TiendaApp.Login
```

### Run Tests
```powershell
# All tests
dotnet test

# Specific test project
dotnet test tests/TiendaApp.Test

# Single test by filter
dotnet test --filter "FullyQualifiedName~TestMethodName"
```

### Clean Build Artifacts
```powershell
dotnet clean
```

### Restore NuGet Packages
```powershell
dotnet restore
```

### Add Project Reference
```powershell
dotnet add src/[ProjectName] reference src/[TargetProject]
```

### Add NuGet Package
```powershell
dotnet add src/[ProjectName] package [PackageName]
```

## Development Notes

### Adding a New Window

1. Create XAML + code-behind in `TiendaApp.UI`
2. Register the window in `TiendaApp.Login/App.xaml.cs` DI container:
   ```csharp
   services.AddTransient<MyNewWindow>();
   ```
3. Resolve and show from another window:
   ```csharp
   var window = App.HostApp.Services.GetRequiredService<MyNewWindow>();
   window.Show();
   ```

### Adding a New Service/Repository

1. Define interface in `TiendaApp.Contrato` (e.g., `IMyService`)
2. Implement in `TiendaApp.Servicio` or `TiendaApp.Repositorio`
3. Register in `TiendaApp.Login/App.xaml.cs`:
   ```csharp
   services.AddTransient<IMyService, MyService>();
   ```
4. Inject via constructor in dependent classes

### Database Changes

- Modify `SchemaSql.cs` to add/alter tables
- Use idempotent SQL (`CREATE TABLE IF NOT EXISTS`, `INSERT WHERE NOT EXISTS`)
- Database is recreated automatically on next run if deleted

### Password Hashing

Use `PasswordHasher.Hash(password)` to hash and `PasswordHasher.Verify(password, hash)` to verify. Never store plaintext passwords.

## Technology Stack

- **Framework**: .NET 9.0
- **UI**: WPF (Windows Presentation Foundation)
- **DI**: Microsoft.Extensions.DependencyInjection + Hosting
- **Database**: SQLite (System.Data.SQLite, Microsoft.Data.Sqlite.Core)
- **ORM**: Dapper
- **Testing**: XUnit
- **Security**: PBKDF2 password hashing (Rfc2898DeriveBytes)
