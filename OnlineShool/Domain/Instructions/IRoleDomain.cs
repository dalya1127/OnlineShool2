
using OnlineShool.Domain;

public interface IRoleDomain    
{
    Task<IReadOnlyList<RoleDomain>> GetAllAsync();
    Task<List<RoleDomain>> GetRolesById(int id);
    Task<RoleDomain> CreateRolesAsync(
        string? Name = null,
        string? Description = null
        );
    Task<RoleDomain> UpdateRolesAsync(
        int id,
        string? Name = null,
        string? Description = null,
        int? IdRole = null
        );
    Task DeleteRolesAsync(int id);
}


