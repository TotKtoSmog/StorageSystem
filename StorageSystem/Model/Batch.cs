namespace StorageSystem.Model
{
    public class Batch
    {
        public int Id { get; set; } 
        public string Article { get; set; }
        public string Title { get; set; }
        public Batch() { }
        public Batch(int id, string article, string title) 
        {
            Id = id;    
            Article = article;
            Title = title;
        }
    }
}
