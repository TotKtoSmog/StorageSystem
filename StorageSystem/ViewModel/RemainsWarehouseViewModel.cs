using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using StorageSystem.Model;
using System.Linq;

namespace StorageSystem.ViewModel
{
    public class RemainsWarehouseViewModel : INotifyPropertyChanged
    {
        private List<WarehouseRemains> _warehouseRemains = new List<WarehouseRemains>();
        public List<WarehouseRemains> warehouseRemains
        {
            get
            {
                return _warehouseRemains;
            }
            set
            {
                _warehouseRemains = value;
                OnPropertyChanged();
            }
        }

        private WarehouseRemains _selectedItemWR = new WarehouseRemains();
        public WarehouseRemains SelectedWarehouse
        {
            get
            {
                return _selectedItemWR;
            }
            set
            {
                _selectedItemWR = value;
                OnPropertyChanged();
            }
        }

        private List<ReportMatInWarehouse> _materialInWarehouseAll = new List<ReportMatInWarehouse>();
        private List<ReportMatInWarehouse> _materialInWarehouse = new List<ReportMatInWarehouse>();
        public List<ReportMatInWarehouse> materialInWarehouse
        {
            get
            {
                return _materialInWarehouse;
            }
            set
            {
                _materialInWarehouse = value;
                OnPropertyChanged();
            }
        }

        private SeriesCollection _diagramData;
        public SeriesCollection DiagramData
        {
            get
            {
                return _diagramData;
            }
            set
            {
                _diagramData = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public DelegateCommand CreateReport
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    DiagramData = CreateDepartamentStatisticPieChart();
                });
            }
        }
        private SeriesCollection CreateDepartamentStatisticPieChart()
        {
            warehouseRemains = LocalDBHendler.GetWarehouseRemains();
            _materialInWarehouseAll = LocalDBHendler.GetReportMatInWarehouse();
            SeriesCollection s = new SeriesCollection();
            foreach(WarehouseRemains wr in warehouseRemains)
            {
                s.Add(new PieSeries
                {
                    Title = wr.Name,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(wr.Quantity) },
                    DataLabels = true
                });
            }
            return s;
        }

    }
}
