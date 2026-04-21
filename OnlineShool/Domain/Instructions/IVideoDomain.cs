
namespace OnlineShool.Domain
{
    public interface IVideoDomain
    {
        Task<List<VideoDomain>> GetVideosByHomeWork(int id);
        Task<List<VideoDomain>> GetVideosByLessons(int id);
        Task<List<VideoDomain>> GetVideosByCourse(int id);

        Task<VideoDomain> CreateVideoAsync(
            string Name,
            string? LinkFile = null,
            string? Description = null
            );
        Task<VideoDomain> UpdateVideoAsync(
            int id,
            string? Name = null,
            string? LinkFile = null,
            string? Description = null
            );


        Task<List<LinksVideoLessonDomain>> GetLinksVideoLessonByLesson(int id);
        Task<List<LinksVideoLessonDomain>> GetLinksVideoLessonByVideo(int id);
        Task<LinksVideoLessonDomain> CreateLinksVideoLessonAsync(
            int IdLessons,
            int IdVideos
            );
        Task<LinksVideoLessonDomain> UpdateLinksVideoLessonAsync(           
            int Id,
            int? IdVideos = null,
            int? IdLessons = null
            );
        Task DeleteVideoAsync(int id);
        Task DeleteLinksVideoLessonAsync(int id);
    }
}
