using Microsoft.AspNet.SignalR.Client;
using Telerik.Windows.Controls;

namespace ClientWPF.ViewModels
{
    public class HubViewModel : ViewModelBase
    {
        protected IHubProxy Proxy { get; set; }

       // protected string url = "http://localhost:59842/";

        protected string url = "http://vracabaceradchat.azurewebsites.net/";

        protected HubConnection Connection { get; set; }

        public HubViewModel()
        {
            {
                this.Connection = new HubConnection(url);

                this.Proxy = Connection.CreateHubProxy("SampleHub");

                this.Connection.Start().Wait();
            }
        }
    }
}
