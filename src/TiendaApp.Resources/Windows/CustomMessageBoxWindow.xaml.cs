using System;
using System.Windows;
using System.Windows.Input;
using TiendaApp.Resources.Controls;
using MessageBoxResult = TiendaApp.Resources.Controls.MessageBoxResult;

namespace TiendaApp.Resources.Windows
{
    public partial class CustomMessageBoxWindow : Window
    {
        public Controls.MessageBoxResult Result { get; private set; }

        public CustomMessageBoxWindow()
        {
            InitializeComponent();
        }

        // Método estático para mostrar el messagebox
        public static MessageBoxResult Show(
            string message,
            string title = "Mensaje",
            MessageBoxType type = MessageBoxType.Info,
            MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            var dialog = new CustomMessageBoxWindow();
            dialog.MessageBoxControl.Title = title;
            dialog.MessageBoxControl.Message = message;
            dialog.MessageBoxControl.MessageType = type;
            dialog.MessageBoxControl.Buttons = buttons;

            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowDialog();

            return dialog.Result;
        }

        // Sobrecarga con opciones adicionales
        public static MessageBoxResult Show(
            string message,
            string title,
            MessageBoxType type,
            MessageBoxButtons buttons,
            string button1Text,
            string button2Text,
            string button3Text = null)
        {
            var dialog = new CustomMessageBoxWindow();
            dialog.MessageBoxControl.Title = title;
            dialog.MessageBoxControl.Message = message;
            dialog.MessageBoxControl.MessageType = type;
            dialog.MessageBoxControl.Buttons = buttons;
            dialog.MessageBoxControl.Button1Text = button1Text;
            dialog.MessageBoxControl.Button2Text = button2Text;
            if (button3Text != null)
                dialog.MessageBoxControl.Button3Text = button3Text;

            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowDialog();

            return dialog.Result;
        }

        private void MessageBoxControl_ResultSelected(object sender, MessageBoxResult result)
        {
            Result = result;
            DialogResult = true;
            Close();
        }

        // Permitir arrastrar la ventana
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
