using Microsoft.Data.Sqlite;
using System.IO;
using SQLitePCL;

namespace TiendaApp.Repositorio.DataInit
{
    public class DatabaseInitializer
    {
        private readonly string _dbPath;

        public DatabaseInitializer()
        {
            _dbPath = PathHelper.GetDatabasePath();
            Batteries.Init(); // Inicializar el proveedor de SQLite
        }

        public void Initialize()
        {
            bool isNew = !File.Exists(_dbPath);

            if (isNew)
                File.Create(_dbPath).Dispose(); // Crear archivo de base de datos

            using var con = new SqliteConnection($"Data Source={_dbPath}");
            con.Open();

            using var cmd = new SqliteCommand(SchemaSql.CreateTables, con);
            cmd.ExecuteNonQuery();
        }
    }
}
