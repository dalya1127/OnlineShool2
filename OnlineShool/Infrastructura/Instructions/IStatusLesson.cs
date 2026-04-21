using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Infrastructura.Instructions
{
    public interface IStatusLesson
    {
        Task<List<StatusLesson>> GetStatusLessonsByLessons(int id);
        Task<List<StatusLesson>> GetStatusLessonsByUser(int id);

        Task<StatusLesson> CreateStatusLessonsAsync(
            string Name,
            string? Description
            );
        Task<StatusLesson> UpdateStatusLessonsAsync(
            int id,
            string? Name = null,
            string? Description = null
            ); 
        Task DeleteStatusLessons(int id);
    }
}
