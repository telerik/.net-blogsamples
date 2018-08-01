using ClientWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ConversationalUI;

namespace ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ChatViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.Icon = new BitmapImage(new Uri("pack://application:,,,/images/chat_wpf_46.png", UriKind.RelativeOrAbsolute));

            RadWindow.Prompt(new DialogParameters
            {
                Content = "Enter an UserName:",
                Closed = new EventHandler<WindowClosedEventArgs>(OnPromptClosed)
            });

        }

        private void OnPromptClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.PromptResult != null && e.PromptResult != string.Empty)
            {
                this.ViewModel = new ChatViewModel(e.PromptResult);
                this.DataContext = this.ViewModel;
                this.myChat.CurrentAuthor = this.ViewModel.CurrentAuthor;
            }

        }

        private void RadChat_SendMessage(object sender, Telerik.Windows.Controls.ConversationalUI.SendMessageEventArgs e)
        {
            this.ViewModel.CurrentMessage = e.Message as TextMessage;

            this.ViewModel.SendCurrentMessage();
        }       
    }
}
