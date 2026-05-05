using OnlineShool.Infrastructura.Sql_Server.Models;
namespace OnlineShool.Infrastructura.Instructions
{
    public interface IVideo
    {
        Task<List<Video>> GetVideosByHomeWork(int id);
        Task<List<Video>> GetVideosByLessons(int id);
        Task<List<Video>> GetVideosByCourse(int id);

        Task<Video> GetById(int id);
        Task<List<Video>> GetAll();

        Task<Video> CreateVideoAsync(
            string Name,
            string? LinkFile = null,
            string? Description = null
            );
        Task<Video> UpdateVideoAsync(
            int id,
            string? Name = null,
            string? LinkFile = null,
            string? Description = null
            );
        Task DeleteVideoAsync(int id);
    }
}
