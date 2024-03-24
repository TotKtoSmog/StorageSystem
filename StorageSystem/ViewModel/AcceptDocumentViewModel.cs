using StorageSystem.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StorageSystem.ViewModel
{
    public class AcceptDocumentViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public AcceptDocumentViewModel()
        {
            if(Mediator.ContainsValue("AcceptDocument"))
                GetDataDocument();
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
        private List<MaterialInDocument> _materialInDocuments = new List<MaterialInDocument>();
        public List<MaterialInDocument> materialInDocuments
        {
            get
            {
                return _materialInDocuments;
            }
            set
            {
                _materialInDocuments = value;
                OnPropertyChanged();
            }
        }
        private void GetDataDocument()
        {
            documentView = (DocumentView)Mediator.getDataFromBuff("AcceptDocument");
            getMaterialInDocument();
        }
        private async void getMaterialInDocument()
            =>materialInDocuments = await LocalDBHendler.GetMaterialInDocument(documentView.Id);
        public DelegateCommand Cancel
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                Mediator.Instance.SendMessage("MainUI", "Documents.xaml")
                );
            }
        }
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
