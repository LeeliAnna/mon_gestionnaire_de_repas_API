using BLL.Forms.User;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static User ToUserForm(this CreateUserForm form)
        {
            return new User
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                Password = form.Password,
                Pseudo = form.Pseudo
            };
        }
    }
}
