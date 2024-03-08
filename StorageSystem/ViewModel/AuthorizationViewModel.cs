using MaterialDesignThemes.Wpf;
using StorageSystem.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace StorageSystem.ViewModel
{
    public class AuthorizationViewModel : INotifyPropertyChanged
    {
        private SnackbarMessageQueue _messagingQueue;
        public SnackbarMessageQueue messageQueue
        {
            get
            {
                return _messagingQueue;
            }
            set { 
                _messagingQueue = value;
                OnPropertyChanged();
            }
        }
        private bool _isLoadBar;
        public bool IsLoadBar
        {
            get 
            { 
                return _isLoadBar; 
            }
            set 
            { 
                _isLoadBar = value;
                OnPropertyChanged();
            }
        }
        private Storekeeper storekeeper { get; set; }
        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        private bool _rememberMe;
        public bool RememberMe
        {
            get
            {
                return _rememberMe;
            }
            set
            {
                _rememberMe = value;
                OnPropertyChanged();
            }
        }
        public AuthorizationViewModel() => GetSettings();
        private void SetSettings(string Login, string Password, bool RememberMe)
        {
            Properties.Settings.Default.Login = Login;
            Properties.Settings.Default.Password = Password;
            Properties.Settings.Default.RememberMe = RememberMe;
            Properties.Settings.Default.Save();
        }
        private void GetSettings()
        {
            IsLoadBar = false;
            messageQueue = new SnackbarMessageQueue();
            Login = Properties.Settings.Default.Login;
            Password = Properties.Settings.Default.Password;
            RememberMe = Properties.Settings.Default.RememberMe;
        }
        public DelegateCommand send
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    if (Login.Length < 5 || Password.Length < 5)
                    {
                        messageQueue.Enqueue("Данные не корректны", null, null, null, false, true, TimeSpan.FromMilliseconds(300));
                    }
                    else
                    {
                        storekeeper = await LocalDBHendler.LogIn(Login, Password);
                        if (storekeeper != null)
                        {
                            messageQueue.Enqueue($"Добро пожаловать {storekeeper.Last_name} {storekeeper.First_name}", null, null, null, false, true, TimeSpan.FromMilliseconds(300));
                            if (RememberMe)
                                SetSettings(Login, Password, RememberMe);
                            else
                                SetSettings("", "", false);
                            IsLoadBar = true;
                            await Task.Delay(1500);
                            Mediator.Instance.SendStoreKeeperDate("MainUI", storekeeper);
                            Mediator.Instance.SendMessage("MainForm", "MainUI.xaml");
                            
                        }
                        else
                            messageQueue.Enqueue("Пользователь не найде", null, null, null, false, true, TimeSpan.FromMilliseconds(300));
                    }
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
