using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfCustomControlsDemo
{
    public partial class ValidatedTextBox : UserControl
    {
        public ValidatedTextBox()
        {
            InitializeComponent();
        }

        // DependencyProperty с валидацией и коррекцией
        public static readonly DependencyProperty NumberValueProperty =
            DependencyProperty.Register(
                "NumberValue",
                typeof(int),
                typeof(ValidatedTextBox),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnNumberValueChanged),
                ValidateNumberValue
            );

        private static bool ValidateNumberValue(object value)
        {
            int val = (int)value;
            // Только положительные числа до 100
            return val >= 0 && val <= 100;
        }

        private static void OnNumberValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (ValidatedTextBox)d;
            control.RaiseEvent(new RoutedEventArgs(NumberValueChangedEvent)); // Bubbling
            control.RaiseEvent(new RoutedEventArgs(NumberChangedEvent));     // Tunneling
        }

        public int NumberValue
        {
            get => (int)GetValue(NumberValueProperty);
            set => SetValue(NumberValueProperty, CoerceNumberValue(this, value));
        }

        // Коррекция значения: если < 0, ставим 0; если > 100, ставим 100
        private static object CoerceNumberValue(DependencyObject d, object baseValue)
        {
            int val = (int)baseValue;
            if (val < 0) return 0;
            if (val > 100) return 100;
            return val;
        }

        // RoutedEvent Bubbling
        public static readonly RoutedEvent NumberValueChangedEvent =
            EventManager.RegisterRoutedEvent(
                "NumberValueChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(ValidatedTextBox));

        public event RoutedEventHandler NumberValueChanged
        {
            add => AddHandler(NumberValueChangedEvent, value);
            remove => RemoveHandler(NumberValueChangedEvent, value);
        }

        // RoutedEvent Tunneling
        public static readonly RoutedEvent NumberChangedEvent =
            EventManager.RegisterRoutedEvent(
                "NumberChanged",
                RoutingStrategy.Tunnel,
                typeof(RoutedEventHandler),
                typeof(ValidatedTextBox));

        public event RoutedEventHandler NumberChanged
        {
            add => AddHandler(NumberChangedEvent, value);
            remove => RemoveHandler(NumberChangedEvent, value);
        }
    }
}