namespace productManagement.Models
{
    public class User
    {
        // Primary key
        public int Id { get; set; }

        // Name or Username, optional
        public string? Name { get; set; }

        // Email must be unique
        public string Email { get; set; }

        // Password stored as plain text (not secure for production)
        public string Password { get; set; }

        // Role: "User", "Admin", etc.
        public string Role { get; set; } = "User"; // default role

        // Constructor with parameters
        public User(string name, string email, string password, string role = "User")
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        // Parameterless constructor (required for EF)
        public User()
        {
        }
    }
}
