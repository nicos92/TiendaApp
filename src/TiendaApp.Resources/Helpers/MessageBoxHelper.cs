using TiendaApp.Resources.Controls;
using TiendaApp.Resources.Windows;

namespace TiendaApp.Resources.Helpers
{
    public static class MessageBoxHelper
    {
        // Métodos rápidos para diferentes tipos de mensajes

        public static MessageBoxResult ShowInfo(string message, string title = "Información")
        {
            return CustomMessageBoxWindow.Show(message, title, MessageBoxType.Info, MessageBoxButtons.OK);
        }

        public static MessageBoxResult ShowWarning(string message, string title = "Advertencia")
        {
            return CustomMessageBoxWindow.Show(message, title, MessageBoxType.Warning, MessageBoxButtons.OK);
        }

        public static MessageBoxResult ShowError(string message, string title = "Error")
        {
            return CustomMessageBoxWindow.Show(message, title, MessageBoxType.Error, MessageBoxButtons.OK);
        }

        public static MessageBoxResult ShowSuccess(string message, string title = "Éxito")
        {
            return CustomMessageBoxWindow.Show(message, title, MessageBoxType.Success, MessageBoxButtons.OK);
        }

        public static MessageBoxResult ShowQuestion(string message, string title = "Confirmación")
        {
            return CustomMessageBoxWindow.Show(message, title, MessageBoxType.Question, MessageBoxButtons.YesNo);
        }

        public static MessageBoxResult ShowConfirm(string message, string title = "Confirmar")
        {
            return CustomMessageBoxWindow.Show(message, title, MessageBoxType.Question, MessageBoxButtons.OKCancel);
        }

        // Métodos con botones personalizados
        public static MessageBoxResult ShowCustom(
            string message,
            string title,
            MessageBoxType type,
            MessageBoxButtons buttons,
            string button1Text = null,
            string button2Text = null,
            string button3Text = null)
        {
            return CustomMessageBoxWindow.Show(message, title, type, buttons, button1Text, button2Text, button3Text);
        }
    }
}
