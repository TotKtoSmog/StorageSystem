using StorageSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StorageSystem.ViewModel
{
    public class BatchesViewModel : INotifyPropertyChanged, IDisposable
    {

        private List<Batch> _batches = new List<Batch>();
        public List<Batch> Batches
        {
            get 
            { 
                return _batches; 
            }
            set 
            { 
                _batches = value;
                OnPropertyChanged();
            }
        }

        private Batch _selectBatch = new Batch();
        public Batch SelectBatch
        {
            get 
            { 
                return _selectBatch; 
            }
            set
            {
                _selectBatch = value;
                OnPropertyChanged();
            }
        }
        public BatchesViewModel()
        {

            Mediator.Instance.RecevingDataPage += OnReceving;
            getDataBatch();
        }
        private void OnReceving(string receiver)
        {
            if(receiver == "Batchs" && (bool)Mediator.getDataFromBuff(receiver))
            {
                getDataBatch();
            }
                
        }
        private void getDataBatch()
        {
            Batches = Directories.Batches;
            if (Batches.Count > 0)
                SelectBatch = Batches.First();
        }


        public DelegateCommand Open
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    Mediator.Instance.SendMessage("MainUI", "Batch.xaml");
                    this.Dispose();
                    //Mediator.Instance.SendDataPage("Batch", SelectBatch);
                });
            }
        }
        public DelegateCommand Create
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    Mediator.Instance.SendMessage("MainUI", "Batch.xaml");
                    this.Dispose();
                });
            }
        }
        public void Dispose()
        {
            Mediator.Instance.RecevingDataPage -= OnReceving;
            Batches = new List<Batch>();
        }
        ~BatchesViewModel()
        {
            Dispose();
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
