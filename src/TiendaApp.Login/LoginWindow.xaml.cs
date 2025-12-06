using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TiendaApp.Contrato.IServicio;
using TiendaApp.Modelo.Entities;
using TiendaApp.Resources;
using TiendaApp.Resources.Controls;
using TiendaApp.Resources.Helpers;
using static System.Net.Mime.MediaTypeNames;
using MessageBoxResult = TiendaApp.Resources.Controls.MessageBoxResult;

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
                    
                    MessageBoxHelper.ShowWarning("Por favor, ingrese DNI y contraseña.", "Advertencia");
                    return;
                }

                var result = MessageBoxHelper.ShowConfirm("¿Desea iniciar sesión con las credenciales proporcionadas?", "Confirmar inicio de sesión");
                if (result != MessageBoxResult.OK)
                {
                    return; // El usuario canceló el inicio de sesión
                }
                // Buscar el usuario por DNI
                Usuario? usuario = await _usuarioServicio.GetByDNIAsync(dni);

                if (usuario == null)
                {
                    
                    MessageBoxHelper.ShowError("DNI o contraseña incorrectos.", "Error");
                    return;
                }

                // Validar credenciales
                Usuario? usuarioValidado = await _usuarioServicio.ValidateCredentialsAsync(usuario.Nombre, password);

                if (usuarioValidado != null)
                {
                   
                    MessageBoxHelper.ShowSuccess("Inicio de sesión exitoso.", "Éxito");
                    // Aquí puedes abrir la ventana principal de la aplicación
                    // Por ahora simplemente cerramos esta ventana
                    this.Close();
                }
                else
                {
                    MessageBoxHelper.ShowError("DNI o contraseña incorrectos.", "Error");
                }
            }
            catch (Exception ex)
            {
                
                MessageBoxHelper.ShowError("Ocurrió un error al intentar iniciar sesión.", "Error");
            }
        }

        private void BtnRecuperarContrasena_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxHelper.ShowInfo("Funcionalidad de recuperación de contraseña no implementada.", "Información");
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
