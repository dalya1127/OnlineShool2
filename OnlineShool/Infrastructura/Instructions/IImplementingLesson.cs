using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Infrastructura.Instructions
{
    public interface IImplementingLesson
    {
        Task<List<ImplementingLesson>> GetImplementingLessonByLessons(int id);
        Task<List<ImplementingLesson>> GetImplementingLessonByUser(int id);
        Task<ImplementingLesson> CreateImplementingLessonAsync(
            int IdUser,
            int IdLessons,
            int IdStatusLessons,
            string? Description = null
            );
        Task<ImplementingLesson> UpdateImplementingLessonAsync(
            int? IdUser = null,
            int? IdLessons = null,
            int? IdStatusLessons = null,
            string? Description = null
            );
        Task DeleteImplementingLesson(int id);
    }
}
