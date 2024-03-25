namespace StorageSystem.Model
{
    public class WarehouseRemains
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity {  get; set; }
        public WarehouseRemains() { }  
        public WarehouseRemains(int id, string name, int quantity)
        {
            ID = id;
            Name = name;
            Quantity = quantity;
        }
    }
}