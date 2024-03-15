using StorageSystem.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StorageSystem.ViewModel
{
    public class DraftViewModel : INotifyPropertyChanged
    {
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

        private DocumentView _documentView;
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

        private DocumentType _selectedItemDT;
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

        private DocumentStatus _selectedItemDS;
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
            documentTypes = Directories.DocumentTypes.OrderBy(n => n.Id).ToList();
            documentStatyses = Directories.DocumentStatuses.OrderBy(n => n.Id).ToList();
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
        public event PropertyChangedEventHandler PropertyChanged;
        private void GetDataDocument()
        {
            documentView = (DocumentView)Mediator.getDataFromBuff("Draft");
            SelectedItemDS = documentStatyses.Where(n => n.Name == documentView.Status).First();
            SelectedItemDT = documentTypes.Where(n => n.Name == documentView.Type).First();
        }
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
