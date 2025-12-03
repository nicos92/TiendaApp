using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using TiendaApp.Login;
using TiendaApp.Repositorio.DataInit;

namespace TiendaApp.UI
{
    public partial class App : Application
    {
        public static IHost HostApp { get; private set; }

        public App()
        {
            HostApp = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Registro del initializer
                    services.AddSingleton<DatabaseInitializer>();

                    //// Registrar repositorios
                    //services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
                    //services.AddTransient<IArticuloRepositorio, ArticuloRepositorio>();
                    //services.AddTransient<IVentaRepositorio, VentaRepositorio>();
                    MessageBox.Show("App ejecutado");
                    //// Registrar servicios
                    //services.AddTransient<IUsuarioServicio, UsuarioServicio>();
                    //services.AddTransient<IArticuloServicio, ArticuloServicio>();
                    //services.AddTransient<IVentaServicio, VentaServicio>();

                    // Registrar ventanas
                    services.AddTransient<MainWindow>();
                    services.AddTransient<LoginWindow>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            var dbInit = HostApp.Services.GetRequiredService<DatabaseInitializer>();
            dbInit.Initialize();     // ← Crea DB + Tablas si no existen
            MessageBox.Show("OnStartup ejecutado");
            await HostApp.StartAsync();

            // Abrir ventana inicial (por ejemplo Login)
            var login = HostApp.Services.GetRequiredService<LoginWindow>();
            login.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            MessageBox.Show("Onexit ejecutado");
            await HostApp.StopAsync();
            HostApp.Dispose();
            base.OnExit(e);
        }
    }
}
