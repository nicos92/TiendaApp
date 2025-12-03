using System;
using System.IO;

namespace TiendaApp.Repositorio.DataInit
{
    public static class PathHelper
    {
        private const string AppFolderName = "TiendaApp";
        private const string DatabaseFileName = "tienda.db";

        public static string GetAppDataFolder()
        {
            string basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appFolder = Path.Combine(basePath, AppFolderName);

            if (!Directory.Exists(appFolder))
                Directory.CreateDirectory(appFolder);

            return appFolder;
        }

        public static string GetDatabasePath()
        {
            string rutaDB = Path.Combine(GetAppDataFolder(), DatabaseFileName);
            Console.WriteLine("Ruta del Archivo: " + Path.Combine(GetAppDataFolder(), DatabaseFileName));
            return rutaDB;
        }
    }
}
