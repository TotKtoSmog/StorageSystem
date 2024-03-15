
namespace StorageSystem.Model
{
    public class WarehousehSortInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WarehousehSortInfo() { }
        public WarehousehSortInfo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
