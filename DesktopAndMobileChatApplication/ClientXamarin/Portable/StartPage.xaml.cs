using ClientXamarin.Portable.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClientXamarin.Portable
{
    public partial class StartPage : ContentPage
    {
        internal LoginViewModel ViewModel { get; }

        public StartPage()
        {
            InitializeComponent();
            this.ViewModel = new LoginViewModel();
            this.BindingContext = this.ViewModel;        }


        private async void Login_Button_Click(object sender, EventArgs e)
        {
            this.NavigateToChatPage();
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            this.NavigateToChatPage();
        }

        private async void NavigateToChatPage()
        {
            if (!string.IsNullOrEmpty(this.ViewModel.UserName))
            {
                var chatPage = new ChatPage(this.ViewModel.UserName);
                await Navigation.PushModalAsync(chatPage);
            }
        }
    }
}