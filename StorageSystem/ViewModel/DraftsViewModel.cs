using StorageSystem.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StorageSystem.ViewModel
{
    public class DraftsViewModel : INotifyPropertyChanged
    {
        private List<DocumentView> _documentViews = new List<DocumentView>();
        public List<DocumentView> documentViews
        {
            get 
            { 
                return _documentViews; 
            }
            set 
            { 
                _documentViews = value;
                OnPropertyChanged();
            }
        }
        private DocumentView _document = new DocumentView();
        public DocumentView Document
        {
            get 
            { 
                return _document; 
            }
            set 
            {
                _document = value;
                OnPropertyChanged(); 
            }
        }
        public DraftsViewModel()
        {
            Mediator.Instance.RecevingDataPage += OnReceivingData;
            documentViews = Directories.DocumentViews.Where(n => n.Status != "Проведен").ToList();
        }
        private void OnReceivingData(string receiver)
        {
            if(receiver == "Drafts" && (bool)Mediator.getDataFromBuff(receiver))
                documentViews = Directories.DocumentViews.Where(n=>n.Status != "Проведен").ToList();
        }
        public DelegateCommand Open
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    Mediator.Instance.SendMessage("MainUI", "Draft.xaml");
                    Mediator.Instance.SendDataPage("Draft", Document);
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
                    Mediator.Instance.SendDataPage("Draft", new DocumentView());
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
