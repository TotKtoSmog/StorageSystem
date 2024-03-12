namespace StorageSystem.Model
{
    public class DocumentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DocumentType() { }
        public DocumentType(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
}
