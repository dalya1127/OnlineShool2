using OnlineShool.Domain;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Application
{
    public class ManagerRole : IRoleDomain
    {


        IRoleRepository _roleRepository;

        public ManagerRole(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;

        }


        private static RoleDomain ConvertRoleToDomain(Role role)
        {
            return new RoleDomain
            {
                Id = role.Id,
                Description = role.Description,
                Name = role.Name
            };
        }

        private static List<RoleDomain> ConvertRoleToList(List<Role> roles)
        {
            var result = new List<RoleDomain>();
            foreach (var roleItem in roles)
            {

                result.Add(ConvertRoleToDomain(roleItem));
            }
            return result;
        }

        private static IReadOnlyList<RoleDomain> ConvertRoleToList(IReadOnlyList<Role> roles)
        {
            var result = new List<RoleDomain>();
            foreach (var roleItem in roles)
            {

                result.Add(ConvertRoleToDomain(roleItem));
            }
            return result;
        }



        public async Task DeleteRolesAsync(int id)
        {
            await _roleRepository.DeleteAsync(id);
        }


        public async Task<RoleDomain> UpdateRolesAsync(int id, string? Name = null, string? Description = null, int? IdRole = null)
        {
            var newRole = await _roleRepository.UpdateAsync(id,Name , Description, IdRole);
            return ConvertRoleToDomain(newRole);
        }

        public async Task<RoleDomain> CreateRolesAsync(string? Name, string? Description)
        {
            var newRole = await _roleRepository.CreateAsync(Name, Description);
            return ConvertRoleToDomain(newRole);
        }

        public async Task<IReadOnlyList<RoleDomain>> GetAllAsync()
        {
            var newRole = await _roleRepository.GetAllAsync();
            return ConvertRoleToList(newRole);
        }

        public async Task<List<RoleDomain>>GetRolesById(int id)
        {
            var newRole = await _roleRepository.GetRolesById(id);
            return ConvertRoleToList(newRole);
        }
    }
}
