
using Microsoft.AspNetCore.Rewrite;
using OnlineShool.Domain;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Application
{
    public class ManagerUser: IUserDomain

    {
        IUserRepository _userRepository;
        public ManagerUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDomain> AuthorizationUserAsync(string Login, string Pasword)
        {
            var userAuth = await _userRepository.AuthorizationUserAsync(Login, Pasword);
            return (userAuth == null) ? null : new UserDomain()
            {
                Id = userAuth.Id,
                FirstName = userAuth.FirstName,
                LastName = userAuth.LastName,
                IdRole = userAuth.IdRole,
                Login = userAuth.Login,
                Email = userAuth.Email,
                Patronymic = userAuth.Patronymic
            };
        }

        public async Task<UserDomain> CreateUserAsync(string FirstName, string LastName, int IdRole, string Login, string Email, string Password, string Patronymic = null)
        {
            var newUser = await _userRepository.CreateUserAsync(FirstName, LastName, IdRole, Login, Email, Password, Patronymic);

            return new UserDomain()
            {
                Id = newUser.Id,
                FirstName = FirstName,
                LastName = LastName,
                IdRole = IdRole,
                Login = Login,
                Email = Email,
                Patronymic = Patronymic
            };
        }

        public async Task DeleteUserAsync(int UserId)
        {
            await _userRepository.DeleteUserAsync(UserId);
        }

        public async Task<IReadOnlyList<UserDomain>> GetAllAsync()
        {
            var usersRep = await _userRepository.GetAllAsync();
            List<UserDomain> resultUsers = new List<UserDomain>();
            foreach (var user in usersRep)
            {
                UserDomain userDomain = new UserDomain();
                userDomain.Id = user.Id;
                userDomain.FirstName = user.FirstName;
                userDomain.LastName = user.LastName;
                userDomain.Password = user.Password;
                userDomain.Email = user.Email;
                userDomain.Login = user.Login;
                userDomain.Role = user.IdRoleNavigation.Name;

            }
            return resultUsers;
        }

        public async Task<UserDomain?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            return new UserDomain
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Patronymic = user.Patronymic,
                Login = user.Login,
                Email = user.Email,
                Role = user.IdRoleNavigation?.Name
            };
        }



        public async Task<UserDomain> UpdateUserAsync(int id, string? FirstName = null, string? LastName = null, string? Patronymic = null, string? Login = null, string? Email = null, string? Password = null, int? IdRole = null)
        {
            var updateUser = await _userRepository.UpdateUserAsync(id, FirstName, LastName, Patronymic, Login, Email, Password, IdRole);
            return new UserDomain()
            {
                Id = updateUser.Id,
                FirstName = updateUser.FirstName,
                LastName = updateUser.LastName,
                Patronymic = updateUser.Patronymic,
                Login = updateUser.Login,
                Email = updateUser.Email,
                Role = updateUser.IdRoleNavigation?.Name

            };
        }
    }
}
