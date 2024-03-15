namespace StorageSystem.Model
{
    public class MaterialInDocument
    {
        public int DocumentId {  get; set; }
        public string Batch { get; set;}
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public MaterialInDocument() { }
        public MaterialInDocument(int documentId, string batch, string materialName, int quantity)
        {
            DocumentId = documentId;
            Batch = batch;
            MaterialName = materialName;
            Quantity = quantity;
        }
    }
}
