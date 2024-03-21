namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        public User CreateUser(User user);
        public bool DeleteUser(int id);
        public bool UpdateUser(User user);
        public User GetUserById(int id);
        public User GetByEmail(string email);
        public List<User> GetAllUsers();
    }
}
