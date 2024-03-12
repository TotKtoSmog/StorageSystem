using StorageSystem.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StorageSystem.ViewModel
{
    public class DraftViewModel : INotifyPropertyChanged
    {
        private string _header;
        public string Header
        {
            get 
            { 
                return _header; 
            }
            set 
            { 
                _header = value; 
                OnPropertyChanged(); 
            }
        }
        public DraftViewModel()
        {
            Header = "Empty";
            Mediator.Instance.RecevingDataPage += OnRecivingData;
            Header = (string)Mediator.getDataFromBuff("Draft");
        }
        public void OnRecivingData(string receiver)
        {
            if (receiver == "Draft")
                Header = (string)Mediator.getDataFromBuff("Draft");
        }
        public DelegateCommand Cancel
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                Mediator.Instance.SendMessage("MainUI", "Drafts.xaml")
                );
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
