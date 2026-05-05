using Microsoft.EntityFrameworkCore;
using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Infrastructura.Sql_Server.Realization
{
    public class UserManager : IUserRepository
    {


        public readonly IDbContextFactory<ApplicationDbContext> _factory;
        public UserManager(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<User> AuthorizationUserAsync(string Login, string Password)
        {
            var _context = _factory.CreateDbContext();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == Login);
            if (user == null) return null;
            if (user.Password == Password) return user;
            else return null;

        }

        public async Task<User> CreateUserAsync(string FirstName,
            string LastName, int IdRole, string Login, string Email,
            string Password, string Patronymic = null)
        {
            var _context = _factory.CreateDbContext();
            User newUser = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                IdRole = IdRole,
                Login = Login,
                Email = Email,
                Password = Password,
                Patronymic = Patronymic

            };
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }


        public async Task DeleteUserAsync(int UserId)
        {
            var _context = _factory.CreateDbContext();
            var removeUser = await _context.Users.FindAsync(UserId);
            if (removeUser == null)
            {
                return;
            }
            _context.Remove(removeUser);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Users.Include( x=> x.IdRoleNavigation).ToListAsync();
            return result;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Users
                .FindAsync(id);
            return result;
        }

        public async Task<User> UpdateUserAsync(int id, string? FirstName = null, string? LastName = null, string? Patronymic = null, string? Login = null, string? Email = null, string? Password = null, int? IdRole = null)
        {
            var _context = _factory.CreateDbContext();
            var updateUser = await _context.Users.FindAsync(id);

            if (updateUser == null)
            {
                throw new Exception("Пользователь не найден");
            }
            if (FirstName != null) updateUser.FirstName =FirstName;
            if (Login != null) updateUser.Login = Login;
            if (LastName != null) updateUser.LastName = LastName;
            if (Patronymic != null) updateUser.Patronymic = Patronymic;
            if (Email != null) updateUser.Email = Email;
            if (Password != null) updateUser.Password = Password;
            await _context.SaveChangesAsync();
            return updateUser;
        }
    }
}
