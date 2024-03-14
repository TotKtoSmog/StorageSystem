namespace StorageSystem.Model
{
    public class DocumentView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Creator { get; set; }
        public string Description { get; set; }
        public string CreateDate { get; set; }
        public string PostingDate { get; set; }
        public string Partner { get; set; }
        public string BasedOn { get; set; }
        public string Status { get; set; }
        public string TotalPriceWithoutTax { get; set; }
        public string TotalPriceWithTax { get; set; }
        public string SourceWarehouse{ get; set; }
        public string DestinationWarehouse { get; set; }
        public string Viewed { get; set; }
        public string Acceptor { get; set; }
        public DocumentView() { }
        public DocumentView(int id, string title, string type, string creator, string description, string createDate, string postingDate, string partner, string basedOn, string status, string totalPriceWithoutTax, string totalPriceWithTax, string sourceWarehouse, string destinationWarehouse, string viewed, string acceptor)
        {
            Id = id;
            Title = title;
            Type = type;
            Creator = creator;
            Description = description;
            CreateDate = createDate;
            PostingDate = postingDate;
            Partner = partner;
            BasedOn = basedOn;
            Status = status;
            TotalPriceWithoutTax = totalPriceWithoutTax;
            TotalPriceWithTax = totalPriceWithTax;
            SourceWarehouse = sourceWarehouse;
            DestinationWarehouse = destinationWarehouse;
            Viewed = viewed;
            Acceptor = acceptor;
        }
    }
}
