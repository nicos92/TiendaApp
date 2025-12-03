# ✅ **1. Estructura de carpetas (CMD / Powershell)**

`mkdir TiendaApp`

`cd TiendaApp`

`mkdir src`

`mkdir tests`

`cd src`

`mkdir TiendaApp.Login`

`mkdir TiendaApp.UI`

`mkdir TiendaApp.Contrato`

`mkdir TiendaApp.Repositorio`

`mkdir TiendaApp.Servicio`

`mkdir TiendaApp.Utilidad`

`cd ..`

---

# ✅ **2. Crear la solución y los proyectos**

## Solución

`dotnet new sln -n TiendaApp`

## Proyecto WPF (UI)

`dotnet new wpf -n TiendaApp.UI -o src/TiendaApp.UI`

## Proyecto consola (Login – PUNTO DE ENTRADA)

`dotnet new wpf -n TiendaApp.Login -o src/TiendaApp.Login`

> **Este será el ejecutable final.**
> Aquí configurás DI, resolvés ventanas y llamás a UI.

## Librerías de clase

`dotnet new classlib -n TiendaApp.Modelo -o src/TiendaApp.Modelo`

`dotnet new classlib -n TiendaApp.Contrato -o src/TiendaApp.Contrato`

`dotnet new classlib -n TiendaApp.Repositorio -o src/TiendaApp.Repositorio`

`dotnet new classlib -n TiendaApp.Servicio -o src/TiendaApp.Servicio`

`dotnet new classlib -n TiendaApp.Utilidad -o src/TiendaApp.Utilidad`

## Proyecto de Test

`dotnet new xunit -n TiendaApp.Test -o tests/TiendaApp.Test`

---

# ✅ **3. Agregar todo a la solución**

`dotnet sln add src/TiendaApp.UI`

`dotnet sln add src/TiendaApp.Login`

`dotnet sln add src/TiendaApp.Modelo`

`dotnet sln add src/TiendaApp.Contrato`

`dotnet sln add src/TiendaApp.Repositorio`

`dotnet sln add src/TiendaApp.Servicio`

`dotnet sln add src/TiendaApp.Utilidad`

`dotnet sln add tests/TiendaApp.Test`

---

# ✅ **4. Referencias entre capas (CORREGIDAS)**

## CAPA LOGIN (punto de inicio)

**Login debe tener acceso a Servicio y Repositorio para configurar DI:**

`dotnet add src/TiendaApp.Login reference src/TiendaApp.Servicio`

`dotnet add src/TiendaApp.Login reference src/TiendaApp.Repositorio`

`dotnet add src/TiendaApp.Login reference src/TiendaApp.Contrato`

`dotnet add src/TiendaApp.Login reference src/TiendaApp.Modelo`

`dotnet add src/TiendaApp.Login reference src/TiendaApp.Utilidad`

`dotnet add src/TiendaApp.Login reference src/TiendaApp.UI`

> IMPORTANTE: Login **sí tiene referencia a UI**,
> pero UI **NO tendrá referencia a Login**, evitando dependencia circular.

---

## CAPA UI (no debe depender de Login)

`dotnet add src/TiendaApp.UI reference src/TiendaApp.Servicio`

`dotnet add src/TiendaApp.UI reference src/TiendaApp.Contrato`

`dotnet add src/TiendaApp.UI reference src/TiendaApp.Modelo`

---

## CAPA SERVICIO (depende de repositorio, contrato y modelo)

`dotnet add src/TiendaApp.Servicio reference src/TiendaApp.Repositorio`

`dotnet add src/TiendaApp.Servicio reference src/TiendaApp.Contrato`

`dotnet add src/TiendaApp.Servicio reference src/TiendaApp.Modelo`

---

## CAPA REPOSITORIO (depende de contrato y modelo)

`dotnet add src/TiendaApp.Repositorio reference src/TiendaApp.Modelo`

`dotnet add src/TiendaApp.Repositorio reference src/TiendaApp.Contrato`

---

## TEST

`dotnet add tests/TiendaApp.Test reference src/TiendaApp.Login`

`dotnet add tests/TiendaApp.Test reference src/TiendaApp.UI`

`dotnet add tests/TiendaApp.Test reference src/TiendaApp.Servicio`

`dotnet add tests/TiendaApp.Test reference src/TiendaApp.Repositorio`

`dotnet add tests/TiendaApp.Test reference src/TiendaApp.Modelo`

`dotnet add tests/TiendaApp.Test reference src/TiendaApp.Contrato`

---

# ✅ **5. Agregar paquetes NuGet**

## Dependency Injection

`dotnet add src/TiendaApp.Login package Microsoft.Extensions.DependencyInjection`

## Para UI (si necesitás servicios dentro de WPF)

`dotnet add src/TiendaApp.UI package Microsoft.Extensions.DependencyInjection`

## SQLite

`dotnet add src/TiendaApp.Repositorio package System.Data.SQLite`

## Dapper (opcional)

`dotnet add src/TiendaApp.Repositorio package Dapper`

---
