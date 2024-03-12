using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StorageSystem.ViewModel
{
    public class DraftsViewModel : INotifyPropertyChanged
    {
        public DelegateCommand Open
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    Mediator.Instance.SendMessage("MainUI", "Draft.xaml");
                    Mediator.Instance.SendDataPage("Draft", "Изменить");
                });
            }
        }
        public DelegateCommand Create
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    Mediator.Instance.SendMessage("MainUI", "Draft.xaml");
                    Mediator.Instance.SendDataPage("Draft", "Создать");
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
