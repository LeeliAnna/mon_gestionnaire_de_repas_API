namespace DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User()
        {
            
        }

        public User(string firstName, string lastName, string pseudo, string email, string password, bool isAdmin = false) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Pseudo = pseudo;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
