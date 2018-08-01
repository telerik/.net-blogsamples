
namespace ClientXamarin.Portable.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
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

        public LoginViewModel()
        {
        }
    }
}
