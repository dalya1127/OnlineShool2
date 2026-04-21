
using Microsoft.EntityFrameworkCore;
using OnlineShool.Infrastructura.Sql_Server.Models;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShool.Infrastructura.Sql_Server.Realization
{
    public class RoleManager : IRoleRepository
    {
        public readonly IDbContextFactory<ApplicationDbContext> _factory;
        public RoleManager(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }
        public async Task<Models.Role> CreateAsync(string? Name = null, string? Description = null)
        {
            var _context = _factory.CreateDbContext();
            Role newRole = new Role()
            {
                Description = Description,
                Name = Name
            };
            await _context.Roles.AddAsync(newRole);
            await _context.SaveChangesAsync();
            return newRole;
        }

        public async Task DeleteAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var removeRole = await _context.Roles.FindAsync(id);
            if (removeRole == null) { return; }
            _context.Roles.Remove(removeRole);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Models.Role>> GetAllAsync()
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Roles.ToListAsync();
            return result;
        }

        public async Task<List<Models.Role>> GetRolesById(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Roles
                .Where(x => x.Id == id)
                .ToListAsync();
            return result;
        }

        public async Task<Models.Role> UpdateAsync(int id,string? Name = null, string? Description = null, int? IdRole = null)
        {
            var _context = _factory.CreateDbContext();
            var updateRole = await _context.Roles.FindAsync(id);
            if (updateRole == null)
            {
                throw new Exception("Роль не найдена");
               
            }
            if (Name != null) updateRole.Name = Name;
            if (Description != null) updateRole.Description = Description;
            await  _context.SaveChangesAsync();
            return updateRole;
        }
    }
}
