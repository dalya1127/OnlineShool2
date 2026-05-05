using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Infrastructura.Instructions
{
    public interface IHomeWork 
    {
        Task<IReadOnlyList<HomeWork>> GetAllAsync();
        Task<HomeWork> GetByIdAsync(int id);
        Task<HomeWork> CreateAsync(
            string Name,
            string? Description,
            string? LinkFile = null
            );
        Task<HomeWork> UpdateAsync(
            int  Id,
            string? LinkFile = null,
            string? Name = null,
            string? Description = null
            );
        Task DeleteAsync(int id);

    }
}
