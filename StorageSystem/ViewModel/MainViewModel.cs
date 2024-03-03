using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace StorageSystem.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {


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
        private string _pageSours = "Authorization.xaml";
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
        public DelegateCommand send
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    /*
                    if(Login.Length < 5 || Password.Length < 5)
                    {
                        MessageBox.Show("нет");
                    }
                    else
                    {
                        
                        if (RememberMe)
                        {
                            MessageBox.Show("Настройки сохранены");
                            SetSettings(Login, Password, RememberMe);
                        }
                        else
                        {
                            SetSettings("","",false);
                        }
                        
                    }*/
                    PageSours = "MainUI.xaml";
                });
            }
        }
        public MainViewModel()
        {
            GetSettings();
        }
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
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
