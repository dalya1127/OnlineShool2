using OnlineShool.Infrastructura.Sql_Server.Models;


public interface ICourseRepository
{
    Task<Course?> GetByIdAsync(int id);
    Task<IReadOnlyList<Course>> GetAllAsync();

    Task<Course>CreateAsync(
        string Name,
        string? Description = null,
        string? LinkPic = null
        );

    Task<Course>UpdateAsync(
        int id,
        string? Name = null,
        string? Description = null,
        string? LinkPic = null
        );

    Task DeleteAsync(int id);
}
