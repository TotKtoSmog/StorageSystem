namespace StorageSystem.Model
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Last_name { get; set; }
        public string First_name { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public User() { }
        public User(int id)
        {
            Id = id;
        }
        public User(int id, string last_name, string firest_name, string patronymic, 
            string login, string password, string position)
        {
            Id = id;
            Last_name = last_name;
            First_name = firest_name;
            Patronymic = patronymic;
            Login = login;
            Password = password;
            Position = position;
        }
    }
}
