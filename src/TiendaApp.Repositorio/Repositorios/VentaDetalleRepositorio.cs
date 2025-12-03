using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using TiendaApp.Contrato.IRepositorio;
using TiendaApp.Modelo.Entities;
using TiendaApp.Repositorio.DataInit;

namespace TiendaApp.Repositorio.Repositorios
{
    public class VentaDetalleRepositorio : BaseRepositorio, IVentaDetalleRepositorio
    {
        public async Task<IEnumerable<VentaDetalle>> GetAllAsync()
        {
            const string sql = "SELECT Id, VentaId, ArticuloId, Cantidad, Precio FROM VentaDetalle";
            using var connection = CreateConnection();
            return await connection.QueryAsync<VentaDetalle>(sql);
        }

        public async Task<VentaDetalle?> GetByIdAsync(int id)
        {
            const string sql = "SELECT Id, VentaId, ArticuloId, Cantidad, Precio FROM VentaDetalle WHERE Id = @Id";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<VentaDetalle>(sql, new { Id = id });
        }

        public async Task<IEnumerable<VentaDetalle>> GetByVentaIdAsync(int ventaId)
        {
            const string sql = "SELECT Id, VentaId, ArticuloId, Cantidad, Precio FROM VentaDetalle WHERE VentaId = @VentaId";
            using var connection = CreateConnection();
            return await connection.QueryAsync<VentaDetalle>(sql, new { VentaId = ventaId });
        }

        public async Task<IEnumerable<VentaDetalle>> GetByArticuloIdAsync(int articuloId)
        {
            const string sql = "SELECT Id, VentaId, ArticuloId, Cantidad, Precio FROM VentaDetalle WHERE ArticuloId = @ArticuloId";
            using var connection = CreateConnection();
            return await connection.QueryAsync<VentaDetalle>(sql, new { ArticuloId = articuloId });
        }

        public async Task<int> CreateAsync(VentaDetalle ventaDetalle)
        {
            const string sql = "INSERT INTO VentaDetalle (VentaId, ArticuloId, Cantidad, Precio) VALUES (@VentaId, @ArticuloId, @Cantidad, @Precio); SELECT last_insert_rowid();";
            using var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, ventaDetalle);
        }

        public async Task<bool> UpdateAsync(VentaDetalle ventaDetalle)
        {
            const string sql = "UPDATE VentaDetalle SET VentaId = @VentaId, ArticuloId = @ArticuloId, Cantidad = @Cantidad, Precio = @Precio WHERE Id = @Id";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, ventaDetalle);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM VentaDetalle WHERE Id = @Id";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }
    }
}