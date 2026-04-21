
using OnlineShool.Infrastructura.Sql_Server.Models;
public interface IRoleRepository
{
    Task<IReadOnlyList<Role>> GetAllAsync();
    Task<List<Role>> GetRolesById(int id);
    Task<Role> CreateAsync(
        string? Name = null,
        string? Description = null
        );
    Task<Role> UpdateAsync(
        int id,
        string? Name = null,
        string? Description = null,
        int? IdRole = null
        );
    Task DeleteAsync(int id);
}


