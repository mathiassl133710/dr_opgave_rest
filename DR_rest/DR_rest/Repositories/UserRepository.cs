namespace DR_rest.Repositories;

public class UserRepository : IUserRepository
{
    // Hardcoded users with roles
    private readonly Dictionary<string, (string Password, string Role)> _users = new()
    {
        { "mathias", ("mathias123!", "user") },
        { "theodor", ("theodor123!", "user") },
        { "admin",   ("password123!", "admin") }
    };

    public (bool success, string role) Validate(string username, string password)
    {
        if (_users.TryGetValue(username, out var user) && user.Password == password)
            return (true, user.Role);

        return (false, string.Empty);
    }
}
