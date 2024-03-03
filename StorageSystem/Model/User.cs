namespace StorageSystem.Model
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public User() { }
        public User(int id)
        {
            Id = id;
        }
        public User(int id, string name, string login, string password)
        {
            Id = id;
            Name = name;
            Login = login;
            Password = password;
        }
    }
}
