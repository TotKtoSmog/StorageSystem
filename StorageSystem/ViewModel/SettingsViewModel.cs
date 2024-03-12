using MaterialDesignThemes.Wpf;
using StorageSystem.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StorageSystem.ViewModel
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private SnackbarMessageQueue _messagingQueue = new SnackbarMessageQueue();
        public SnackbarMessageQueue messageQueue
        {
            get
            {
                return _messagingQueue;
            }
            set
            {
                _messagingQueue = value;
                OnPropertyChanged();
            }
        }
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
            messageQueue = new SnackbarMessageQueue();
            StoreKeeper = new Storekeeper();
            StoreKeeperTemp = new Storekeeper();
            Mediator.Instance.ReceivingDateStoreKeeper += ReceivingData;
            StoreKeeper = (Storekeeper)Mediator.getDataFromBuff("Settings");
            StoreKeeperTemp = (Storekeeper)StoreKeeper.Clone();
        }
        private void ReceivingData(string receiver)
        {
            if (receiver == "Settings")
                StoreKeeper = (Storekeeper)Mediator.getDataFromBuff(receiver);
        }
        
        public DelegateCommand Save
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    string result = await LocalDBHendler.UpdateStorekeeper(StoreKeeperTemp);
                    messageQueue.Enqueue( result, null, null, null, false, true, TimeSpan.FromMilliseconds(500));
                    StoreKeeper = (Storekeeper)StoreKeeperTemp.Clone();
                });
            }
        }
        public DelegateCommand Cansel
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    StoreKeeperTemp = (Storekeeper)StoreKeeper.Clone();
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
