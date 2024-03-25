namespace StorageSystem.ViewModel
{
    public class ReportsViewModel
    {
        public DelegateCommand RemainsWarehouse
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    Mediator.Instance.SendMessage("MainUI", "RemainsWarehouse.xaml");
                });
            }

        }
    }
}
