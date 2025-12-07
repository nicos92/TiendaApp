using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using TiendaApp.Contrato.IRepositorio;
using TiendaApp.Contrato.IServicio;
using TiendaApp.Contrato.IWindow;
using TiendaApp.Repositorio.DataInit;
using TiendaApp.Repositorio.Repositorios;
using TiendaApp.Resources;
using TiendaApp.Servicio.Dominio;
using TiendaApp.UI;

namespace TiendaApp.Login
{
    public partial class App : Application
    {
        public static IHost HostApp { get; private set; }

        protected override async void OnStartup(StartupEventArgs e)
        {
            // Inicializar el host aquí para evitar problemas de orden de ejecución
            HostApp = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Registro del initializer
                    services.AddSingleton<DatabaseInitializer>();

                    //// Registrar repositorios
                    services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
                    services.AddTransient<IArticuloRepositorio, ArticuloRepositorio>();
                    services.AddTransient<IVentaRepositorio, VentaRepositorio>();
                    //// Registrar servicios
                    services.AddTransient<IUsuarioServicio, UsuarioServicio>();
                    services.AddTransient<IArticuloServicio, ArticuloServicio>();
                    services.AddTransient<IVentaServicio, VentaServicio>();

                    // Registrar ventanas
                    services.AddTransient<MainWindow>();
                    services.AddTransient<LoginWindow>();

                    services.AddTransient<IWindowService, WindowService>();
                })
                .Build();

            var dbInit = HostApp.Services.GetRequiredService<DatabaseInitializer>();
            dbInit.Initialize();     // ← Crea DB + Tablas si no existen
            await HostApp.StartAsync();

            // Inicializar el ThemeManager después de que se configuren los servicios
            ThemeManager.Initialize();


            // Abrir ventana inicial (por ejemplo Login)
            //var login = HostApp.Services.GetRequiredService<LoginWindow>();
            //login.Show();

            // Usar WindowService para abrir la primera ventana
            var windowService = HostApp.Services.GetRequiredService<IWindowService>();
            windowService.ShowLoginWindow();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            if (HostApp != null)
            {
                await HostApp.StopAsync();
                HostApp.Dispose();
            }
            base.OnExit(e);
        }
    }
}
