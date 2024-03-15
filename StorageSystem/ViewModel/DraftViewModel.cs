using StorageSystem.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StorageSystem.ViewModel
{
    public class DraftViewModel : INotifyPropertyChanged
    {
        private List<WarehousehSortInfo> _sourceWarehouse = new List<WarehousehSortInfo>();
        public List<WarehousehSortInfo> sourceWarehouse
        {
            get
            {
                return _sourceWarehouse;
            }
            set
            {
                _sourceWarehouse = value;
                OnPropertyChanged();
            }
        }
        private List<WarehousehSortInfo> _destinationWarehouse = new List<WarehousehSortInfo>();
        public List<WarehousehSortInfo> destinationWarehouse
        {
            get
            {
                return _destinationWarehouse;
            }
            set
            {
                _destinationWarehouse = value;
                OnPropertyChanged();
            }
        }
        private WarehousehSortInfo _selectedItemsSW = new WarehousehSortInfo();
        public WarehousehSortInfo selectedItemsSW
        {
            get
            {
                return _selectedItemsSW;
            }
            set
            {
                _selectedItemsSW = value;
                OnPropertyChanged();
            }
        }
        private WarehousehSortInfo _selectedItemsDW = new WarehousehSortInfo();
        public WarehousehSortInfo selectedItemsDW
        {
            get
            {
                return _selectedItemsDW;
            }
            set
            {
                _selectedItemsDW = value;
                OnPropertyChanged();
            }
        }
        private List<DocumentType> _docTypes = new List<DocumentType>();
        public List<DocumentType> documentTypes
        {
            get 
            { 
                return _docTypes;
            }
            set 
            { 
                _docTypes = value; 
                OnPropertyChanged(); 
            }
        }
        private List<DocumentStatus> _docStatyses = new List<DocumentStatus>();
        public List<DocumentStatus> documentStatyses
        {
            get
            {
                return _docStatyses;
            }
            set
            {
                _docStatyses = value;
                OnPropertyChanged();
            }
        }
        private DocumentView _documentView = new DocumentView();
        public DocumentView documentView 
        { 
            get 
            { 
                return _documentView; 
            } 
            set
            {
                _documentView = value;
                OnPropertyChanged();
            }
        }  
        private string _header = "Empty";
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
        private DocumentType _selectedItemDT = new DocumentType();
        public DocumentType SelectedItemDT
        {
            get 
            { 
                return _selectedItemDT; 
            }
            set
            {
                _selectedItemDT = value;
                OnPropertyChanged();
            }
        }
        private DocumentStatus _selectedItemDS = new DocumentStatus();
        public DocumentStatus SelectedItemDS
        {
            get
            {
                return _selectedItemDS;
            }
            set
            {
                _selectedItemDS = value;
                OnPropertyChanged();
            }
        }
        public DraftViewModel()
        {
            if (Mediator.ContainsValue("Draft"))
                GetDataDocument();
        }
        public DelegateCommand Cancel
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                Mediator.Instance.SendMessage("MainUI", "Documents.xaml")
                );
            }
        }
        private void GetDataDocument()
        {
            documentTypes = Directories.DocumentTypes.OrderBy(n => n.Id).ToList();
            documentStatyses = Directories.DocumentStatuses.OrderBy(n => n.Id).ToList();
            destinationWarehouse = Directories.WarehousehSortInfos.OrderBy(n => n.Id).ToList();
            sourceWarehouse = Directories.WarehousehSortInfos.OrderBy(n => n.Id).ToList();
            documentView = (DocumentView)Mediator.getDataFromBuff("Draft");

            selectedItemsSW = sourceWarehouse.Where(n => n.Name == documentView.SourceWarehouse).DefaultIfEmpty().First();
            selectedItemsDW = destinationWarehouse.Where(n => n.Name == documentView.DestinationWarehouse).DefaultIfEmpty().First();
            SelectedItemDS = documentStatyses.Where(n => n.Name == documentView.Status).DefaultIfEmpty().First();
            SelectedItemDT = documentTypes.Where(n => n.Name == documentView.Type).DefaultIfEmpty().First();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
