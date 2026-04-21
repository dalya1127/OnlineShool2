using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Infrastructura.Instructions
{
    public interface IImplementingHomeWork
    {
        Task<List<ImplementingHomeWork>> GetImplementingHomeworkByUserAsync(int id);
        Task<List<ImplementingHomeWork>> GetImplementingHomeworkByHomeworkAsync(int id);
        Task<ImplementingHomeWork> CreateAsync(
            int IdUser,
            int IdHomeWork,
            int IdStatusHomeWork,
            string? LinkFile = null,
            int? Score = null
            );
        Task<ImplementingHomeWork> UpdateAsync(
            int id,
            int? IdUser = null,
            int? IdHomeWork = null,
            int? IdStatusHomeWork = null,
            string? LinkFile = null,
            int? Score = null
            );
        Task DeleteImplementingHW(int id);
    }
}
