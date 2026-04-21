
using OnlineShool.Infrastructura.Sql_Server.Models;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IReadOnlyList<User>> GetAllAsync();
    Task<User> CreateUserAsync(
        string FirstName, 
        string LastName,
        int IdRole, 
        string Login, 
        string Email,
        string Password,
        string Patronymic = null
        
        );
    Task<User> AuthorizationUserAsync(
        string Login,
        string Password
        );

    Task<User> UpdateUserAsync(
        int id,
        string? FirstName = null,
        string? LastName = null,
        string? Patronymic = null,
        string? Login = null,
        string? Email = null,
        string? Password = null,
        int? IdRole = null
        );

    Task DeleteUserAsync(
        int UserId
        );
}
