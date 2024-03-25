namespace StorageSystem.Model
{
    public class ReportMatInWarehouse
    {
        public int WarehouseId {  get; set; }
        public string BatchArticle { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public ReportMatInWarehouse() { }
        public ReportMatInWarehouse(int warehouseId, string batchArticle, string title, string type, int quantity)
        {
            WarehouseId = warehouseId;
            BatchArticle = batchArticle;
            Title = title;
            Type = type;
            Quantity = quantity;
        }
    }
}
