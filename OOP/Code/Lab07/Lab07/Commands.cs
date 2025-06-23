using System.Windows.Input;

namespace WpfCustomControlsDemo
{
    public static class Commands
    {
        public static readonly RoutedUICommand MyCustomCommand = new RoutedUICommand(
            "Моя команда",
            "MyCustomCommand",
            typeof(Commands)
        );
    }
}