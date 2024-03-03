namespace StorageSystem.Model
{
    public class Storekeeper:User
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Storekeeper() : base() { }
        public Storekeeper(int id): base(id) { }
        public Storekeeper(int id, string name, string login, string password):
            base(id, name, login, password) { }
    }
}
