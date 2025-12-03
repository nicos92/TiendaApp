using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.IO;

namespace TiendaApp.Repositorio.DataInit
{
    public class DatabaseInitializer
    {
        private readonly string _dbPath;

        public DatabaseInitializer()
        {
            _dbPath = PathHelper.GetDatabasePath();
        }

        public void Initialize()
        {
            bool isNew = !File.Exists(_dbPath);

            if (isNew)
                SQLiteConnection.CreateFile(_dbPath);

            using var con = new SqliteConnection($"Data Source={_dbPath}");
            con.Open();

            using var cmd = new SqliteCommand(SchemaSql.CreateTables, con);
            cmd.ExecuteNonQuery();
        }
    }
}
