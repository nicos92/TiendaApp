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
SELECT 'superadmin', 'Super', '00000000', '100000.wJN6ViU+vJ6fR9bC2zZc6w==.qLUh1qiDKoJKrjlQ5qjy5i3VeKqsXWDhyehV+CTvHdI='
WHERE NOT EXISTS (SELECT 1 FROM Usuarios WHERE Nombre = 'superadmin');

INSERT INTO Usuarios (Nombre, Apellido, DNI, Password)
SELECT 'admin', 'Administrador', '11111111', '100000.Y3GvwTgJ7VyVLULCChFqHw==.tsnhVRmcSR8c0nDXmKxx6YGo2JogB2C021/Cr8YWmy8='
WHERE NOT EXISTS (SELECT 1 FROM Usuarios WHERE Nombre = 'admin');

INSERT INTO Usuarios (Nombre, Apellido, DNI, Password)
SELECT 'gerente', 'Gerente', '22222222', '100000.9IjldYgrPkdLJRDXyF0ihA==.n61Vb7SJxwwO0MCqK0NqODtm8yUggYOBn3bEzGXawlE='
WHERE NOT EXISTS (SELECT 1 FROM Usuarios WHERE Nombre = 'gerente');

INSERT INTO Usuarios (Nombre, Apellido, DNI, Password)
SELECT 'supervisor', 'Supervisor', '33333333', '100000.KmT9vWcKnfEVPecEzJxHrA==.h6UsJFlCy8YVm2pmDRVHyTqQ6JJxdS1fX3baQS5VE0U='
WHERE NOT EXISTS (SELECT 1 FROM Usuarios WHERE Nombre = 'supervisor');

INSERT INTO Usuarios (Nombre, Apellido, DNI, Password)
SELECT 'encargado', 'Encargado', '44444444', '100000.0Ty0YpNszl7hLjKZfEN5Gw==.tsF7XcrrrN2V3slmytYH8HFcY/HzMhPgH9MgfHBMU2I='
WHERE NOT EXISTS (SELECT 1 FROM Usuarios WHERE Nombre = 'encargado');

INSERT INTO Usuarios (Nombre, Apellido, DNI, Password)
SELECT 'empleado', 'Empleado', '55555555', '100000.0g4m7x36yFlXHADKFkC1SQ==.Ma9iAHuPGrfG8i2yPMAVIgFk0YuBB1B2Mpk8keMQKSI='
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
