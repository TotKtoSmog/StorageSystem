using System;

namespace StorageSystem.Model
{
    public class Storekeeper:User, ICloneable
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

        public object Clone()
        {
            return new Storekeeper(Id, Last_name, First_name, Patronymic,
            Login, Password, Position, PhoneNumber, Email);
        }
    }
}
