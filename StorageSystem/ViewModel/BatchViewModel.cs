using StorageSystem.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StorageSystem.ViewModel
{
    public class BatchViewModel : INotifyPropertyChanged
    {
        public Batch Batch { get; set; }

        public DelegateCommand Cancel
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    Mediator.Instance.SendMessage("MainUI", "Batches.xaml");
                    
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
