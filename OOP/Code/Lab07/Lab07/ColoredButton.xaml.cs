using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCustomControlsDemo
{
    public partial class ColoredButton : UserControl
    {
        public ColoredButton()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        // DependencyProperty с валидацией и коррекцией
        public static readonly DependencyProperty ButtonColorProperty =
            DependencyProperty.Register(
                "ButtonColor",
                typeof(Brush),
                typeof(ColoredButton),
                new FrameworkPropertyMetadata(Brushes.LightGray, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, CoerceButtonColor),
                ValidateButtonColor
            );

        private static bool ValidateButtonColor(object value)
        {
            // Только SolidColorBrush
            return value is SolidColorBrush;
        }

        private static object CoerceButtonColor(DependencyObject d, object baseValue)
        {
            if (baseValue is SolidColorBrush brush)
                return brush;
            // Если не тот тип, используем по умолчанию
            return Brushes.LightGray;
        }

        public Brush ButtonColor
        {
            get => (Brush)GetValue(ButtonColorProperty);
            set => SetValue(ButtonColorProperty, value);
        }

        // RoutedEvent Direct
        public static readonly RoutedEvent ButtonClickedEvent =
            EventManager.RegisterRoutedEvent(
                "ButtonClicked",
                RoutingStrategy.Direct,
                typeof(RoutedEventHandler),
                typeof(ColoredButton));

        public event RoutedEventHandler ButtonClicked
        {
            add => AddHandler(ButtonClickedEvent, value);
            remove => RemoveHandler(ButtonClickedEvent, value);
        }

        // RoutedEvent Tunneling
        public static readonly RoutedEvent ButtonPressedEvent =
            EventManager.RegisterRoutedEvent(
                "ButtonPressed",
                RoutingStrategy.Tunnel,
                typeof(RoutedEventHandler),
                typeof(ColoredButton));

        public event RoutedEventHandler ButtonPressed
        {
            add => AddHandler(ButtonPressedEvent, value);
            remove => RemoveHandler(ButtonPressedEvent, value);
        }

        // Direct - Clicked
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ButtonClickedEvent));
        }

        // Tunneling - Pressed
        private void Button_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ButtonPressedEvent));
        }
    }
}