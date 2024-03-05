namespace StorageSystem.Model
{
    public class Storekeeper:User
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Storekeeper() : base() { }
        public Storekeeper(int id): base(id) { }
        public Storekeeper(int id, string last_name, string firest_name, string patronymic,
            string login, string password, string position, string phoneNumber, string email) :
            base(id, last_name, firest_name, patronymic, login, password, position)
        {
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
