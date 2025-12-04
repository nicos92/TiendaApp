using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TiendaApp.Contrato.IServicio;
using TiendaApp.Modelo.Entities;
using TiendaApp.Resources;
using static System.Net.Mime.MediaTypeNames;

namespace TiendaApp.Login
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUsuarioServicio _usuarioServicio;
        private bool theme;

        public LoginWindow(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
            InitializeComponent();
            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            BtnLogin.Click += BtnLogin_Click;
            BtnRecuperarContrasena.Click += BtnRecuperarContrasena_Click;
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string dni = TxtDni.Text.Trim();
                string password = TxtPass.Password.Trim();

                if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Por favor, ingrese DNI y contraseña.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Buscar el usuario por DNI
                Usuario? usuario = await _usuarioServicio.GetByDNIAsync(dni);

                if (usuario == null)
                {
                    MessageBox.Show("DNI o contraseña incorrectos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Validar credenciales
                Usuario? usuarioValidado = await _usuarioServicio.ValidateCredentialsAsync(usuario.Nombre, password);

                if (usuarioValidado != null)
                {
                    MessageBox.Show($"¡Bienvenido, {usuario.Nombre} {usuario.Apellido}!", "Inicio de sesión exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Aquí puedes abrir la ventana principal de la aplicación
                    // Por ahora simplemente cerramos esta ventana
                    this.Close();
                }
                else
                {
                    MessageBox.Show("DNI o contraseña incorrectos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnRecuperarContrasena_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Funcionalidad de recuperación de contraseña no implementada.", "Recuperar Contraseña", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (theme)
            {
                ThemeManager.SetDarkTheme();

            }
            else
                ThemeManager.SetLightTheme();

            ImgTheme.Source = theme
           ? new BitmapImage(new Uri("pack://application:,,,/resources/icons/moon-fill.png"))
           : new BitmapImage(new Uri("pack://application:,,,/resources/icons/brightness-high-fill.png"));

            theme = !theme;
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var image = button.Content as System.Windows.Controls.Image;

            if (TxtPass.Visibility != Visibility.Visible)
            {
                // Ocultar contraseña
                TxtPass.Password = VisibleTxtPass.Text;
                TxtPass.Visibility = Visibility.Visible;
                VisibleTxtPass.Visibility = Visibility.Collapsed;

                // Cambiar icono a ojo cerrado
                image.Source = new BitmapImage(new Uri("pack://application:,,,/resources/icons/eye-slash.png"));
            }
            else
            {
                // Mostrar contraseña
                VisibleTxtPass.Text = TxtPass.Password;
                VisibleTxtPass.Visibility = Visibility.Visible;
                TxtPass.Visibility = Visibility.Collapsed;

                // Cambiar icono a ojo abierto
                image.Source = new BitmapImage(new Uri("pack://application:,,,/resources/icons/eye.png"));
            }
        }
    }

}
