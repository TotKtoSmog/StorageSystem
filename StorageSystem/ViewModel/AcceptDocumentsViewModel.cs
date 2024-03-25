using StorageSystem.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StorageSystem.ViewModel
{
    public class AcceptDocumentsViewModel : INotifyPropertyChanged
    {
        private string _surch;
        public string Surch
        {
            get
            {
                return _surch;
            }
            set
            {
                _surch = value;
                //documentViews.Where(n => n.Title.Contains(_surch)).ToList();
                OnPropertyChanged();
            }
        }

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
        public AcceptDocumentsViewModel()
        {
            Mediator.Instance.RecevingDataPage += OnReceivingData;
        }
        private void OnReceivingData(string receiver)
        {
            SetDataGrid();
        }
        private void SetDataGrid()
        {
            documentViews = Directories.DocumentViews.Where(n => n.Status == "Проведен").ToList();
            Document = documentViews.DefaultIfEmpty(new DocumentView()).First();
        }
        public DelegateCommand SurchTextChenged
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                { });
            }
        }
        public DelegateCommand Open
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    Mediator.Instance.SendMessage("MainUI", "AcceptDocument.xaml");
                    Mediator.Instance.SendDataPage("AcceptDocument", Document);
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
