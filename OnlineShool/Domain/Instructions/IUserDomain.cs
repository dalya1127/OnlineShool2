
namespace OnlineShool.Domain;

public interface IUserDomain
{
    Task<UserDomain?> GetByIdAsync(int id);
    Task<IReadOnlyList<UserDomain>> GetAllAsync();
    Task<UserDomain> CreateUserAsync(
        string FirstName, 
        string LastName,
        int IdRole, 
        string Login, 
        string Email,
        string Password,
        string? Patronymic = null
        
        );

    Task<UserDomain> AuthorizationUserAsync(
        string Login,
        string Pasword
        );

    Task<UserDomain> UpdateUserAsync(
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
