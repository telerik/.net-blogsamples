using System.Windows;
using Telerik.Windows.Controls;

namespace ClientWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            StyleManager.ApplicationTheme = new FluentTheme();
        }
    }
}
