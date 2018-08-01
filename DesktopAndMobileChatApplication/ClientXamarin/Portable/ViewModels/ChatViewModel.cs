using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.ObjectModel;
using Telerik.XamarinForms.ConversationalUI;
using Xamarin.Forms;

namespace ClientXamarin.Portable.ViewModels
{
    public class ChatViewModel : HubViewModel
    {
        private string mCurrentMessage;
        public string CurrentMessage
        {
            get { return mCurrentMessage; }
            set
            {
                if (value != null || value != mCurrentMessage)
                {
                    mCurrentMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        private string mUserName;
        public string UserName
        {
            get { return mUserName; }
            set
            {
                if (value != null || value != mUserName)
                {
                    mUserName = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<TextMessage> allMessages;
        public ObservableCollection<TextMessage> AllMessages
        {
            get { return allMessages; }
            set
            {
                if (value != null || value != allMessages)
                {
                    allMessages = value;
                    OnPropertyChanged();
                }
            }
        }

        public ChatViewModel(string userName)
        {
            this.UserName = userName;
            this.AllMessages = new ObservableCollection<TextMessage>();

            // Invokes the Register method on the server
            this.Proxy.Invoke("Register", this.UserName);

            // Subscribes to the broadcastMessage method on the server. 
            // The OnBroadCastMessage method will be raised everytime the Send method on the server is invoked.
            this.Proxy.On("broadcastMessage", (string from, string message) => this.OnBroadCastMessage(from, message));
        }

        internal void OnBroadCastMessage(string from, string message)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread((Action)(() =>
            {
                this.AllMessages.Add(new TextMessage() { Author = new Author() { Name = from, Avatar = string.Empty }, Text = message });
            }));
        }

        internal void SendCurrentMessage()
        {
            if (!string.IsNullOrEmpty(this.CurrentMessage))
            {
                this.Proxy.Invoke("Send", this.UserName, this.CurrentMessage);
            }
        }
    }
}
