using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfCustomControlsDemo
{
    public partial class MainWindow : Window
    {
        // Пользовательская команда
        public static RoutedUICommand MyCustomCommand = new RoutedUICommand(
            "Моя команда",
            "MyCustomCommand",
            typeof(MainWindow),
            new InputGestureCollection() { new KeyGesture(Key.F5) });

        public MainWindow()
        {
            InitializeComponent();
        }

        // Демонстрация RoutedEvent: Bubbling (ValidatedTextBox_NumberValueChanged)
        private void ValidatedTextBox_NumberValueChanged(object sender, RoutedEventArgs e)
        {
            if (InfoText == null)
            {
                MessageBox.Show("InfoText еще не инициализирован");
                return;
            }
            InfoText.Text = "Bubbling: NumberValueChanged (ValidatedTextBox)";
        }

        // Демонстрация RoutedEvent: Tunneling (ValidatedTextBox_NumberChanged)
        private void ValidatedTextBox_NumberChanged(object sender, RoutedEventArgs e)
        {
            if (InfoText == null)
            {
                MessageBox.Show("InfoText == null");
                return;
            }
            InfoText.Text = "Tunneling: NumberChanged (ValidatedTextBox)";
        }

        // Демонстрация RoutedEvent: Direct (ColoredButton_ButtonClicked)
        private void ColoredButton_ButtonClicked(object sender, RoutedEventArgs e)
        {
            if (InfoText == null)
            {
                MessageBox.Show("InfoText == null");
                return;
            }
            InfoText.Text = "Direct: ButtonClicked (ColoredButton)";
        }

        // Демонстрация RoutedEvent: Tunneling (ColoredButton_ButtonPressed)
        private void ColoredButton_ButtonPressed(object sender, RoutedEventArgs e)
        {
            if (InfoText == null)
            {
                MessageBox.Show("InfoText == null");
                return;
            }
            InfoText.Text = "Tunneling: ButtonPressed (ColoredButton)";
        }

        // Реализация пользовательской команды
        private void MyCustomCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (InfoText == null)
            {
                MessageBox.Show("InfoText == null");
                return;
            }
            InfoText.Text = "Пользовательская команда выполнена!";
        }

        // Для демонстрации PreviewMouseDown на StackPanel (Tunneling)
        private void MainStack_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Для примера, не заполняем
        }
    }
}