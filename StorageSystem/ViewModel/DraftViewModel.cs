using StorageSystem.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

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
        public DraftViewModel()
        {
            documentTypes = new List<DocumentType>();
            if(Mediator.ContainsValue("Draft"))
                Header = ((DocumentView)Mediator.getDataFromBuff("Draft")).Creator;

            documentTypes = Directories.DocumentTypes.OrderBy(n=>n.Id).ToList();
            documentStatyses = Directories.DocumentStatuses.OrderBy(n => n.Id).ToList();
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
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
