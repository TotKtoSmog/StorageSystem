using StorageSystem.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StorageSystem.ViewModel
{
    public class MainUIViewModel : INotifyPropertyChanged
    {
        private string _sourceReport;
        public string SourceReport
        {
            get
            {
                return _sourceReport;
            }
            set
            {
                _sourceReport = value;
                OnPropertyChanged();
            }
        }
        
        private string _sourceDocuments;
        public string SourceDocuments
        {
            get 
            { 
                return _sourceDocuments; 
            }
            set {
                _sourceDocuments = value;
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
            Mediator.Instance.GoToPage += OnOpenPage;
            SourceDocuments = "Documents.xaml";
            SourceReport = "Reports.xaml";
            Mediator.Instance.ReceivingDateStoreKeeper += OnReceivingStoreKeeperDate;
            StoreKeeper = (Storekeeper)Mediator.getDataFromBuff("MainUI");
            if(StoreKeeper != null)
            {
                TopLogo = $"{StoreKeeper.Last_name[0]}{StoreKeeper.First_name[0]}";
                Mediator.Instance.SendStoreKeeperDate("Settings", StoreKeeper);
                GetDirectorys();
            }
        }
        private async void GetDirectorys()
        {
            Directories.SetDocumentView(await LocalDBHendler.GetDocumentInfo());
            Directories.SetDocumentType(await LocalDBHendler.GetDocumentType());
            Directories.SetwarehousehSortInfo(await LocalDBHendler.GetWarehousehSortInfo());
            Directories.SetDocumentStatus(await LocalDBHendler.GetDocumentStatus());
            Mediator.Instance.SendDataPage("Drafts", true);
        }
        private void OnOpenPage(string receiver)
        {
            if (receiver == "MainUI")
            {
                string path = (string)Mediator.getDataFromBuff(receiver);
                switch (path)
                {
                    case "AcceptDocument.xaml":
                    case "Draft.xaml":
                    case "Documents.xaml":
                        SourceDocuments = path; break;
                    case "Reports.xaml":
                    case "RemainsWarehouse.xaml": SourceReport = path; break;
                }
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
