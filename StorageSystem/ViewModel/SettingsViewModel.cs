using StorageSystem.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StorageSystem.ViewModel
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private Storekeeper _storekeeperTemp = new Storekeeper();
        public Storekeeper StoreKeeperTemp
        {
            get
            {
                return _storekeeperTemp;
            }
            set
            {
                _storekeeperTemp = value;
                OnPropertyChanged();
            }
        }
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
        public SettingsViewModel()
        {
            Mediator.Instance.ReceivingDateStoreKeeper += ReceivingData;
            StoreKeeper = (Storekeeper)Mediator.getDataFromBuff("Settings");
            StoreKeeperTemp = StoreKeeper;
        }
        private void ReceivingData(string receiver)
        {
            if (receiver == "Settings")
                StoreKeeper = (Storekeeper)Mediator.getDataFromBuff(receiver);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
