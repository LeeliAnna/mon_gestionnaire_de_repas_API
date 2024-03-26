using BLL.Forms.User;
using BLL.Mappers;

namespace BLL.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        //Package Nugget Bcrypt.net-next
        public User? CreateUser(CreateUserForm form)
        {
            User u = _repository.GetByEmail(form.Email);

            if (u is not null && u.IsActive == false)
            {
                u.IsActive = true;
                return u;
            }

            if (u == null)
            {
                User user = form.ToUserForm();
                user.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
                _repository.CreateUser(user);
                return user;
            }
            return null;
        }

        public bool UpdateUser(UpdatePasswordForm form)
        {
            User u = _repository.GetUserById(form.UserId);
            if(u is not null)
            {
                if(BCrypt.Net.BCrypt.Verify(form.OldPassword, u.Password))
                {
                    u.Password = BCrypt.Net.BCrypt.HashPassword(form.NewPassword);
                    return _repository.UpdateUser(u);
                }
            }
            return false;
        }

        public bool DeleteUser(int id)
        {
            User u = _repository.GetUserById(id);
            if (u is not null) return _repository.DeleteUser(id);
            return false;
        }

        public IEnumerable<User> GetAllUsers() 
        {
            return _repository.GetAllUsers();
        }

        public User GetById(int id)
        {
            return _repository.GetUserById(id);
        }

        public User? Login(string mail, string password)
        {
            User? u = _repository.GetByEmail(mail);
            if(BCrypt.Net.BCrypt.Verify(password, u.Password))
            {
                return u;
            }
            return null;
        }

    }
}
