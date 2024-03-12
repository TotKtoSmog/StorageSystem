namespace StorageSystem.Model
{
    public class DocumentStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DocumentStatus() { }
        public DocumentStatus(int id, string name) 
        {  
            Id = id; 
            Name = name; 
        }
    }
}
