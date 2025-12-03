namespace TiendaApp.Repositorio.DataInit
{
    public static class SchemaSql
    {
        public const string CreateTables = @"

CREATE TABLE IF NOT EXISTS Usuarios(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT NOT NULL,
    Apellido TEXT NOT NULL,
    DNI TEXT NOT NULL,
    Password TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Roles(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS UsuariosRoles(
    UsuarioId INTEGER NOT NULL,
    RolId INTEGER NOT NULL,
    FOREIGN KEY(UsuarioId) REFERENCES Usuarios(Id),
    FOREIGN KEY(RolId) REFERENCES Roles(Id)
);

CREATE TABLE IF NOT EXISTS Articulos(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT NOT NULL,
    Precio REAL NOT NULL,
    Stock INTEGER NOT NULL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS Ventas(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Fecha TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS VentaDetalle(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    VentaId INTEGER NOT NULL,
    ArticuloId INTEGER NOT NULL,
    Cantidad INTEGER NOT NULL,
    Precio REAL NOT NULL,
    FOREIGN KEY(VentaId) REFERENCES Ventas(Id),
    FOREIGN KEY(ArticuloId) REFERENCES Articulos(Id)
);

INSERT INTO Roles (Nombre)
SELECT 'superadministrador'
WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE Nombre = 'superadministrador');

INSERT INTO Roles (Nombre)
SELECT 'administrador'
WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE Nombre = 'administrador');

INSERT INTO Roles (Nombre)
SELECT 'gerente'
WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE Nombre = 'gerente');

INSERT INTO Roles (Nombre)
SELECT 'supervisor'
WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE Nombre = 'supervisor');

INSERT INTO Roles (Nombre)
SELECT 'encargado'
WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE Nombre = 'encargado');

INSERT INTO Roles (Nombre)
SELECT 'empleado'
WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE Nombre = 'empleado');

INSERT INTO Usuarios (Nombre, Apellido, DNI, Password)
SELECT 'superadmin', 'Super', '00000000', '100000.wfAOkhEBe4o8IPAdK02Mfw==.eKXotWkGjpW6k6SeVIuvK7CFdCGS+oLjJ/IXgfES8t4='
WHERE NOT EXISTS (SELECT 1 FROM Usuarios WHERE Nombre = 'superadmin');

INSERT INTO Usuarios (Nombre, Apellido, DNI, Password)
SELECT 'admin', 'Administrador', '11111111', '100000.YN0lzjO2GJfwD+9vQgCEgw==.Xvf0UIHx6JuC+6JYPtOFw1ukx69rUXlpCafks+KQpJ8='
WHERE NOT EXISTS (SELECT 1 FROM Usuarios WHERE Nombre = 'admin');

INSERT INTO Usuarios (Nombre, Apellido, DNI, Password)
SELECT 'gerente', 'Gerente', '22222222', '100000.tFZZOprs/uOyHrIEIgHsAA==.+s7c3nwXbVzifLStJvedBDixiZKiRf0AASGBEY3PTXI='
WHERE NOT EXISTS (SELECT 1 FROM Usuarios WHERE Nombre = 'gerente');

INSERT INTO Usuarios (Nombre, Apellido, DNI, Password)
SELECT 'supervisor', 'Supervisor', '33333333', '100000.agAxrn926Jr2EAoQRwPRyA==.o/Sk224Fiqnvz4CACsmSCzecP7G15iMloyv0SojC1go='
WHERE NOT EXISTS (SELECT 1 FROM Usuarios WHERE Nombre = 'supervisor');

INSERT INTO Usuarios (Nombre, Apellido, DNI, Password)
SELECT 'encargado', 'Encargado', '44444444', '100000.3y7VhOar2xh705K8QzKSRg==.uHKuAHaM8vwPYJiHJrbwB+LrydiDSW9YCaRfMJ8Xszo='
WHERE NOT EXISTS (SELECT 1 FROM Usuarios WHERE Nombre = 'encargado');

INSERT INTO Usuarios (Nombre, Apellido, DNI, Password)
SELECT 'empleado', 'Empleado', '55555555', '100000.wQ94MblQeZL+105iUbGiAw==.+twXq+mN3mS56xzFKPw50EBehnXW/z3qcNyZD7w5/9g='
WHERE NOT EXISTS (SELECT 1 FROM Usuarios WHERE Nombre = 'empleado');

INSERT INTO UsuariosRoles (UsuarioId, RolId)
SELECT u.Id, r.Id
FROM Usuarios u
JOIN Roles r ON r.Nombre = 'superadministrador'
WHERE u.Nombre = 'superadmin'
AND NOT EXISTS (
    SELECT 1 FROM UsuariosRoles WHERE UsuarioId = u.Id AND RolId = r.Id
);

INSERT INTO UsuariosRoles (UsuarioId, RolId)
SELECT u.Id, r.Id
FROM Usuarios u
JOIN Roles r ON r.Nombre = 'administrador'
WHERE u.Nombre = 'admin'
AND NOT EXISTS (
    SELECT 1 FROM UsuariosRoles WHERE UsuarioId = u.Id AND RolId = r.Id
);

INSERT INTO UsuariosRoles (UsuarioId, RolId)
SELECT u.Id, r.Id
FROM Usuarios u
JOIN Roles r ON r.Nombre = 'gerente'
WHERE u.Nombre = 'gerente'
AND NOT EXISTS (
    SELECT 1 FROM UsuariosRoles WHERE UsuarioId = u.Id AND RolId = r.Id
);

INSERT INTO UsuariosRoles (UsuarioId, RolId)
SELECT u.Id, r.Id
FROM Usuarios u
JOIN Roles r ON r.Nombre = 'supervisor'
WHERE u.Nombre = 'supervisor'
AND NOT EXISTS (
    SELECT 1 FROM UsuariosRoles WHERE UsuarioId = u.Id AND RolId = r.Id
);

INSERT INTO UsuariosRoles (UsuarioId, RolId)
SELECT u.Id, r.Id
FROM Usuarios u
JOIN Roles r ON r.Nombre = 'encargado'
WHERE u.Nombre = 'encargado'
AND NOT EXISTS (
    SELECT 1 FROM UsuariosRoles WHERE UsuarioId = u.Id AND RolId = r.Id
);

INSERT INTO UsuariosRoles (UsuarioId, RolId)
SELECT u.Id, r.Id
FROM Usuarios u
JOIN Roles r ON r.Nombre = 'empleado'
WHERE u.Nombre = 'empleado'
AND NOT EXISTS (
    SELECT 1 FROM UsuariosRoles WHERE UsuarioId = u.Id AND RolId = r.Id
);
";
    }
}
