using StorageSystem.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace StorageSystem.ViewModel
{
    public class AuthorizationViewModel : INotifyPropertyChanged
    {
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
                        MessageBox.Show("Данные не корректны", "Неудача(");
                    }
                    else
                    {
                        storekeeper = await LocalDBHendler.LogIn(Login, Password);
                        if (storekeeper != null)
                        {
                            MessageBox.Show($"{storekeeper.Last_name} {storekeeper.First_name}", "Успешно");
                            if (RememberMe)
                                SetSettings(Login, Password, RememberMe);
                            else
                                SetSettings("", "", false);

                            Mediator.Instance.SendStoreKeeperDate("MainUI", storekeeper);
                            Mediator.Instance.SendMessage("MainForm", "MainUI.xaml");
                        }    
                        else
                            MessageBox.Show($"Пользователь не найде", "Неудача(");
                    }
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
