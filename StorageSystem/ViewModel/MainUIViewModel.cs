using StorageSystem.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StorageSystem.ViewModel
{
    public class MainUIViewModel : INotifyPropertyChanged
    {
        private Storekeeper _storekeeper = new Storekeeper();
        public Storekeeper StoreKeeper
        {
            get
            {
                return _storekeeper;
            }
            set
            {
                _storekeeper = value;
                OnPropertyChanged();
            }
        }

        private string _topLogo;
        public string TopLogo
        {
            get
            { 
                return _topLogo; 
            }
            set
            {
                _topLogo = value;
                OnPropertyChanged();
            }
        }
        public MainUIViewModel()
        {
            Mediator.Instance.ReceivingDateStoreKeeper += OnReceivingStoreKeeperDate;
            StoreKeeper = (Storekeeper)Mediator.getDataFromBuff("MainUI");
            if(StoreKeeper != null)
            {
                TopLogo = $"{StoreKeeper.Last_name[0]}{StoreKeeper.First_name[0]}";
                Mediator.Instance.SendStoreKeeperDate("Settings", StoreKeeper);
            }
                

        }
        private void OnReceivingStoreKeeperDate(string receiver)
        {
            if (receiver == "MainUI")
                StoreKeeper = (Storekeeper)Mediator.getDataFromBuff(receiver);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
