using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TiendaApp.Resources.Controls
{
    // Enums necesarios
    public enum MessageBoxType
    {
        Info,
        Warning,
        Error,
        Success,
        Question
    }

    public enum MessageBoxButtons
    {
        OK,
        OKCancel,
        YesNo,
        YesNoCancel,
        RetryCancel,
        AbortRetryIgnore
    }

    public enum MessageBoxResult
    {
        None = 0,
        OK = 1,
        Cancel = 2,
        Yes = 6,
        No = 7,
        Abort = 3,
        Retry = 4,
        Ignore = 5
    }

    public partial class CustomMessageBox : UserControl
    {
        // Elementos del XAML
        private Path _messageIcon;
        private TextBlock _titleText;
        private TextBlock _messageText;
        private Button _button1;
        private Button _button2;
        private Button _button3;

        // Eventos
        public event EventHandler<MessageBoxResult> ResultSelected;

        public CustomMessageBox()
        {
            InitializeComponent();
            Loaded += CustomMessageBox_Loaded;
        }

        private void CustomMessageBox_Loaded(object sender, RoutedEventArgs e)
        {
            // Obtener referencias a los elementos
            FindVisualElements();

            // Inicializar con valores por defecto
            UpdateMessageType(MessageType);
            UpdateButtons(Buttons);

            // Actualizar textos iniciales
            if (_titleText != null) _titleText.Text = Title;
            if (_messageText != null) _messageText.Text = Message;
            if (_button1 != null) _button1.Content = Button1Text;
            if (_button2 != null) _button2.Content = Button2Text;
            if (_button3 != null) _button3.Content = Button3Text;
        }

        private void FindVisualElements()
        {
            // Buscar elementos por nombre
            _messageIcon = FindName("PART_MessageIcon") as Path;
            _titleText = FindName("PART_TitleText") as TextBlock;
            _messageText = FindName("PART_MessageText") as TextBlock;
            _button1 = FindName("PART_Button1") as Button;
            _button2 = FindName("PART_Button2") as Button;
            _button3 = FindName("PART_Button3") as Button;
        }

        #region Propiedades Dependencia

        // Título
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string),
                typeof(CustomMessageBox), new PropertyMetadata("Título", OnTitleChanged));

        private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomMessageBox control && control._titleText != null)
            {
                control._titleText.Text = e.NewValue as string;
            }
        }

        // Mensaje
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string),
                typeof(CustomMessageBox), new PropertyMetadata("Mensaje", OnMessageChanged));

        private static void OnMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomMessageBox control && control._messageText != null)
            {
                control._messageText.Text = e.NewValue as string;
            }
        }

        // Tipo de mensaje
        public MessageBoxType MessageType
        {
            get { return (MessageBoxType)GetValue(MessageTypeProperty); }
            set { SetValue(MessageTypeProperty, value); }
        }

        public static readonly DependencyProperty MessageTypeProperty =
            DependencyProperty.Register("MessageType", typeof(MessageBoxType),
                typeof(CustomMessageBox), new PropertyMetadata(MessageBoxType.Info, OnMessageTypeChanged));

        private static void OnMessageTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomMessageBox control)
            {
                control.UpdateMessageType((MessageBoxType)e.NewValue);
            }
        }

        // Botones a mostrar
        public MessageBoxButtons Buttons
        {
            get { return (MessageBoxButtons)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

        public static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.Register("Buttons", typeof(MessageBoxButtons),
                typeof(CustomMessageBox), new PropertyMetadata(MessageBoxButtons.OKCancel, OnButtonsChanged));

        private static void OnButtonsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomMessageBox control)
            {
                control.UpdateButtons((MessageBoxButtons)e.NewValue);
            }
        }

        // Textos personalizados para botones
        public string Button1Text
        {
            get { return (string)GetValue(Button1TextProperty); }
            set { SetValue(Button1TextProperty, value); }
        }

        public static readonly DependencyProperty Button1TextProperty =
            DependencyProperty.Register("Button1Text", typeof(string),
                typeof(CustomMessageBox), new PropertyMetadata("Cancelar", OnButton1TextChanged));

        private static void OnButton1TextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomMessageBox control && control._button1 != null)
            {
                control._button1.Content = e.NewValue as string;
            }
        }

        public string Button2Text
        {
            get { return (string)GetValue(Button2TextProperty); }
            set { SetValue(Button2TextProperty, value); }
        }

        public static readonly DependencyProperty Button2TextProperty =
            DependencyProperty.Register("Button2Text", typeof(string),
                typeof(CustomMessageBox), new PropertyMetadata("Aceptar", OnButton2TextChanged));

        private static void OnButton2TextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomMessageBox control && control._button2 != null)
            {
                control._button2.Content = e.NewValue as string;
            }
        }

        public string Button3Text
        {
            get { return (string)GetValue(Button3TextProperty); }
            set { SetValue(Button3TextProperty, value); }
        }

        public static readonly DependencyProperty Button3TextProperty =
            DependencyProperty.Register("Button3Text", typeof(string),
                typeof(CustomMessageBox), new PropertyMetadata("Opcional", OnButton3TextChanged));

        private static void OnButton3TextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomMessageBox control && control._button3 != null)
            {
                control._button3.Content = e.NewValue as string;
            }
        }

        #endregion

        #region Métodos de actualización

        private void UpdateMessageType(MessageBoxType type)
        {
            if (_messageIcon == null) return;

            // Buscar en recursos
            var resources = Application.Current.Resources;

            Geometry iconData = null;
            Brush iconBrush = null;

            switch (type)
            {
                case MessageBoxType.Info:
                    iconData = FindResource("InfoIcon") as Geometry;
                    iconBrush = resources["PrimaryBrush"] as Brush;
                    break;

                case MessageBoxType.Warning:
                    iconData = FindResource("WarningIcon") as Geometry;
                    iconBrush = resources["WarningBrush"] as Brush ?? Brushes.Orange;
                    break;

                case MessageBoxType.Error:
                    iconData = FindResource("ErrorIcon") as Geometry;
                    iconBrush = resources["ErrorBrush"] as Brush ?? Brushes.Red;
                    break;

                case MessageBoxType.Success:
                    iconData = FindResource("SuccessIcon") as Geometry;
                    iconBrush = resources["SuccessBrush"] as Brush ?? Brushes.Green;
                    break;

                case MessageBoxType.Question:
                    iconData = FindResource("QuestionIcon") as Geometry;
                    iconBrush = resources["PrimaryBrush"] as Brush;
                    break;
            }

            // Si no se encuentra en recursos locales, usar valores por defecto
            if (iconData == null)
            {
                switch (type)
                {
                    case MessageBoxType.Info:
                        iconData = Geometry.Parse("M12,2C6.48,2 2,6.48 2,12s4.48,10 10,10 10,-4.48 10,-10S17.52,2 12,2zM13,17h-2v-6h2v6zM13,9h-2V7h2v2z");
                        break;
                    case MessageBoxType.Warning:
                        iconData = Geometry.Parse("M12,2L1,21h22L12,2z M13,18h-2v-2h2v2z M13,14h-2v-4h2v4z");
                        break;
                    case MessageBoxType.Error:
                        iconData = Geometry.Parse("M12,2C6.47,2 2,6.47 2,12s4.47,10 10,10 10,-4.47 10,-10S17.53,2 12,2zM17,15.59L15.59,17 12,13.41 8.41,17 7,15.59 10.59,12 7,8.41 8.41,7 12,10.59 15.59,7 17,8.41 13.41,12 17,15.59z");
                        break;
                    case MessageBoxType.Success:
                        iconData = Geometry.Parse("M12,2C6.48,2 2,6.48 2,12s4.48,10 10,10 10,-4.48 10,-10S17.52,2 12,2zM10,17l-5,-5 1.41,-1.41L10,14.17l7.59,-7.59L19,8l-9,9z");
                        break;
                    case MessageBoxType.Question:
                        iconData = Geometry.Parse("M12,2C6.48,2 2,6.48 2,12s4.48,10 10,10 10,-4.48 10,-10S17.52,2 12,2zM13,19h-2v-2h2v2zM15.07,11.25l-0.9,0.92C13.45,12.89 13,13.5 13,15h-2v-0.5c0,-1.1 0.45,-2.1 1.17,-2.83l1.24,-1.26c0.37,-0.36 0.59,-0.86 0.59,-1.41c0,-1.1 -0.9,-2 -2,-2s-2,0.9 -2,2H8c0,-2.21 1.79,-4 4,-4s4,1.79 4,4c0,0.88 -0.36,1.68 -0.93,2.25z");
                        break;
                }
            }

            if (iconData != null)
                _messageIcon.Data = iconData;

            if (iconBrush != null)
                _messageIcon.Fill = iconBrush;
            else
                _messageIcon.Fill = Brushes.Blue; // Color por defecto
        }

        private void UpdateButtons(MessageBoxButtons buttons)
        {
            if (_button1 == null || _button2 == null || _button3 == null) return;

            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    _button1.Visibility = Visibility.Collapsed;
                    _button2.Content = "Aceptar";
                    _button3.Visibility = Visibility.Collapsed;
                    break;

                case MessageBoxButtons.OKCancel:
                    _button1.Visibility = Visibility.Visible;
                    _button1.Content = Button1Text;
                    _button2.Content = Button2Text;
                    _button3.Visibility = Visibility.Collapsed;
                    break;

                case MessageBoxButtons.YesNo:
                    _button1.Visibility = Visibility.Visible;
                    _button1.Content = "No";
                    _button2.Content = "Sí";
                    _button3.Visibility = Visibility.Collapsed;
                    break;

                case MessageBoxButtons.YesNoCancel:
                    _button1.Visibility = Visibility.Visible;
                    _button1.Content = "Cancelar";
                    _button2.Content = "Sí";
                    _button3.Visibility = Visibility.Visible;
                    _button3.Content = "No";
                    break;

                case MessageBoxButtons.RetryCancel:
                    _button1.Visibility = Visibility.Visible;
                    _button1.Content = "Cancelar";
                    _button2.Content = "Reintentar";
                    _button3.Visibility = Visibility.Collapsed;
                    break;

                case MessageBoxButtons.AbortRetryIgnore:
                    _button1.Visibility = Visibility.Visible;
                    _button1.Content = "Abortar";
                    _button2.Content = "Reintentar";
                    _button3.Visibility = Visibility.Visible;
                    _button3.Content = "Ignorar";
                    break;
            }
        }

        #endregion

        #region Event Handlers

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = GetResultForButton(1);
            ResultSelected?.Invoke(this, result);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = GetResultForButton(2);
            ResultSelected?.Invoke(this, result);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = GetResultForButton(3);
            ResultSelected?.Invoke(this, result);
        }

        private MessageBoxResult GetResultForButton(int buttonNumber)
        {
            switch (Buttons)
            {
                case MessageBoxButtons.OK:
                    return MessageBoxResult.OK;

                case MessageBoxButtons.OKCancel:
                    return buttonNumber == 1 ? MessageBoxResult.Cancel : MessageBoxResult.OK;

                case MessageBoxButtons.YesNo:
                    return buttonNumber == 1 ? MessageBoxResult.No : MessageBoxResult.Yes;

                case MessageBoxButtons.YesNoCancel:
                    if (buttonNumber == 1) return MessageBoxResult.Cancel;
                    if (buttonNumber == 2) return MessageBoxResult.Yes;
                    return MessageBoxResult.No;

                case MessageBoxButtons.RetryCancel:
                    return buttonNumber == 1 ? MessageBoxResult.Cancel : MessageBoxResult.Retry;

                case MessageBoxButtons.AbortRetryIgnore:
                    if (buttonNumber == 1) return MessageBoxResult.Abort;
                    if (buttonNumber == 2) return MessageBoxResult.Retry;
                    return MessageBoxResult.Ignore;

                default:
                    return MessageBoxResult.None;
            }
        }

        #endregion
    }
}
