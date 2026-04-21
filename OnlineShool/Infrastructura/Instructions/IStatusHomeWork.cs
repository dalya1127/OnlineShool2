using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Infrastructura.Instructions
{
    public interface IStatusHomeWork
    {
        Task<List<StatusHomeWork>> GetStatusHomeWorkByLessons(int id);
        Task<List<StatusHomeWork>> GetStatusHomeWorkByUser(int id);
        Task<List<StatusHomeWork>> GetStatusHomeWorkByHomeWork(int id);

        Task<StatusHomeWork> CreateStatusHomeWorkAsync(
            string Name,
            string? Description
            );
        Task<StatusHomeWork> UpdateStatusHomeWorkAsync(
            int id,
            string? Name = null,
            string? Description = null
            );
        Task DeleteStatusHomeWork (int id);
    }
}
