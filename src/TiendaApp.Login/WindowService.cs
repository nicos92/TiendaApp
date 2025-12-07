using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TiendaApp.Contrato.IWindow;
using TiendaApp.UI;

namespace TiendaApp.Login
{
    public class WindowService(IServiceProvider serviceProvider) : IWindowService
    {
        private Window? _currentWindow;

        public void ShowMainWindow()
        {
            // Obtener la ventana principal del otro proyecto (UI)
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();

            // Ocultar la ventana actual si existe
            if (_currentWindow != null && _currentWindow != mainWindow)
            {
                _currentWindow.Hide();
            }

            // Mostrar la nueva ventana
            mainWindow.Show();
            _currentWindow = mainWindow;
        }

        public void ShowLoginWindow()
        {
            var loginWindow = serviceProvider.GetRequiredService<LoginWindow>();

            if (_currentWindow != null && _currentWindow != loginWindow)
            {
                _currentWindow.Hide();
            }

            loginWindow.Show();
            _currentWindow = loginWindow;
        }

        public void CloseCurrentWindow()
        {
            _currentWindow?.Close();
            _currentWindow = null;
        }
    }
}
