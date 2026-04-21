using OnlineShool.Infrastructura.Sql_Server.Models;
namespace OnlineShool.Infrastructura.Instructions
{
    public interface ILinksVideoLesson
    {
        Task<List<LinksVideoLesson>> GetLinksVideoLessonByLesson(int id);
        Task<List<LinksVideoLesson>> GetLinksVideoLessonByVideo(int id);
        Task<LinksVideoLesson> CreateLinksVideoLessonAsync(
            int IdLessons,
            int IdVideos
            );
        Task<LinksVideoLesson> UpdateLinksVideoLessonAsync(
            int id,
            int? IdVideos = null,
            int? IdLessons = null
            );
        Task DeleteLinksVideoLessonAsync(int id);
    }
}