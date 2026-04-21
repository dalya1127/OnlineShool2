
using OnlineShool.Infrastructura.Sql_Server.Models;
public interface ILessonRepository
{
    Task<Lesson?> GetByIdAsync(int id);
    Task<IReadOnlyList<Lesson>> GetAllAsync();
    Task<IReadOnlyList<Lesson>> GetByCourseIdAsync(int courseId);

    Task<Lesson> CreateLessonAsync(
        int IdCourses,
        string Name,
        int NumberLessons,
        string? LinkFile = null,
        string? LinkPic = null,
        string? Description = null
        );

    Task<Lesson> UpdateLessonAsync(
        int id,
        int? IdCourses = null,
        string? Name = null,
        int? NumberLessons = null,
        string? LinkFile = null,
        string? LinkPic = null,
        string? Description = null
        );
    Task DeleteLessonAsync(int id);
}
