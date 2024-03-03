using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StorageSystem.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _pageSours;
        public string PageSours
        {
            get
            {
                return _pageSours;
            }
            set
            {
                _pageSours = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            Mediator.Instance.GoToMainUI += OnMessageReceived;
            PageSours = "Authorization.xaml";
        }
        private void OnMessageReceived(string receiver, string message)
        {
            if(receiver == "MainForm")
                PageSours = message;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
