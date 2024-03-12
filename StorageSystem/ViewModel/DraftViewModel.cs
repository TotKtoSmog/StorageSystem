using StorageSystem.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

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
        private string _header;
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
            Header = "Empty";
            Mediator.Instance.RecevingDataPage += OnRecivingData;
            Header = (string)Mediator.getDataFromBuff("Draft");
            documentTypes = Directorys.DocumentTypes.OrderBy(n=>n.Id).ToList();
            documentStatyses = Directorys.DocumentStatuses.OrderBy(n => n.Id).ToList();
        }
        public void OnRecivingData(string receiver)
        {
            if (receiver == "Draft")
                Header = (string)Mediator.getDataFromBuff("Draft");
        }
        public DelegateCommand Cancel
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                Mediator.Instance.SendMessage("MainUI", "Drafts.xaml")
                );
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
