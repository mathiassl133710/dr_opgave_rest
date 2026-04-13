namespace DR_rest.Repositories;

public interface IUserRepository
{
    (bool success, string role) Validate(string username, string password);
}
