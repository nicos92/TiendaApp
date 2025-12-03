using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using TiendaApp.Contrato.IRepositorio;
using TiendaApp.Modelo.Entities;
using TiendaApp.Repositorio.DataInit;

namespace TiendaApp.Repositorio.Repositorios
{
    public class ArticuloRepositorio : BaseRepositorio, IArticuloRepositorio
    {
        public async Task<IEnumerable<Articulo>> GetAllAsync()
        {
            const string sql = "SELECT Id, Nombre, Precio, Stock FROM Articulos";
            using var connection = CreateConnection();
            return await connection.QueryAsync<Articulo>(sql);
        }

        public async Task<Articulo?> GetByIdAsync(int id)
        {
            const string sql = "SELECT Id, Nombre, Precio, Stock FROM Articulos WHERE Id = @Id";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Articulo>(sql, new { Id = id });
        }

        public async Task<Articulo?> GetByNameAsync(string nombre)
        {
            const string sql = "SELECT Id, Nombre, Precio, Stock FROM Articulos WHERE Nombre = @Nombre";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Articulo>(sql, new { Nombre = nombre });
        }

        public async Task<int> CreateAsync(Articulo articulo)
        {
            const string sql = "INSERT INTO Articulos (Nombre, Precio, Stock) VALUES (@Nombre, @Precio, @Stock); SELECT last_insert_rowid();";
            using var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, articulo);
        }

        public async Task<bool> UpdateAsync(Articulo articulo)
        {
            const string sql = "UPDATE Articulos SET Nombre = @Nombre, Precio = @Precio, Stock = @Stock WHERE Id = @Id";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, articulo);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Articulos WHERE Id = @Id";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }
    }
}