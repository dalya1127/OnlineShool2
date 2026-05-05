using OnlineShool.Domain;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Application
{
    public class ManagerVideo : IVideoDomain
    {
        IVideo _videoRepository;
        ILinksVideoLesson _linksVideoLesson;
        public ManagerVideo(IVideo videoRepository, ILinksVideoLesson linksVideoRepository)
        {
            _videoRepository = videoRepository;
            _linksVideoLesson = linksVideoRepository;
        }

        private static VideoDomain ConvertVideoToDomain(Video video)
        {
            return new VideoDomain
            {
                Id = video.Id,
                LinkFile = video.LinkFile,
                Description = video.Description,
                Name = video.Name
            };
        }


        private static LinksVideoLessonDomain ConvertLinkToDomain(LinksVideoLesson link)
        {
            return new LinksVideoLessonDomain
            {
            Id = link.Id,
            IdLessons = link.IdLessons,
            IdVideos = link.IdVideos,
            };
        }
         
        private static List<LinksVideoLessonDomain> ConvertLinkToList(List<LinksVideoLesson> link)
        {              
            var result = new List<LinksVideoLessonDomain>();
            foreach (var linkItem in link)
            {
                result.Add(ConvertLinkToDomain(linkItem));
            }
            return result;
         
            
        }


        private static List<VideoDomain> ConvertVideoToList(List<Video> link)
        {
            var result = new List<VideoDomain>();
            foreach (var linkItem in link)
            {
                result.Add(ConvertVideoToDomain(linkItem));
            }
            return result;


        }

        public async Task<LinksVideoLessonDomain> CreateLinksVideoLessonAsync(int IdLessons, int IdVideos)
        {
            var newLink = await _linksVideoLesson.CreateLinksVideoLessonAsync( IdLessons, IdVideos);

            return ConvertLinkToDomain(newLink);
        }

        public async Task<VideoDomain> CreateVideoAsync(string Name, string? LinkFile = null, string? Description = null)
        {
            var newVideo = await _videoRepository.CreateVideoAsync( 
                Name, 
                LinkFile,
                Description);

            return ConvertVideoToDomain(newVideo);
        }

        public async Task DeleteLinksVideoLessonAsync(int id)
        {
            await _linksVideoLesson.DeleteLinksVideoLessonAsync(id);
        }
        

        public async Task DeleteVideoAsync(int id)
        {
            await _videoRepository.DeleteVideoAsync(id);
        }

        public async Task<List<LinksVideoLessonDomain>> GetLinksVideoLessonByLesson(int id)
        {
            var links = await _linksVideoLesson.GetLinksVideoLessonByLesson(id);
            
            return ConvertLinkToList(links);
        }

        public async Task<List<LinksVideoLessonDomain>> GetLinksVideoLessonByVideo(int id)
        {
            var links = await _linksVideoLesson.GetLinksVideoLessonByVideo(id);
            return ConvertLinkToList(links);
        }

        public async Task<List<VideoDomain>> GetVideosByCourse(int id)
        {
            var links = await _videoRepository.GetVideosByCourse(id);
            return ConvertVideoToList(links);
        }

        public async Task<List<VideoDomain>> GetVideosByHomeWork(int id)
        {
            var links = await _videoRepository.GetVideosByHomeWork(id);
            return ConvertVideoToList(links);
        }

        public async Task<List<VideoDomain>> GetVideosByLessons(int id)
        {
            var links = await _videoRepository.GetVideosByLessons(id);
            return ConvertVideoToList(links);
        }

        public async Task<LinksVideoLessonDomain> UpdateLinksVideoLessonAsync(int IdLinksVideoLesson, int? IdVideos = null, int? IdLessons = null)
        {
            var links = await _linksVideoLesson.UpdateLinksVideoLessonAsync(IdLinksVideoLesson, IdVideos, IdLessons);

            return ConvertLinkToDomain(links);
        }

        public async Task<VideoDomain> UpdateVideoAsync(int id,string? Name = null, string? LinkFile = null, string? Description = null)
        {
            var links = await _videoRepository.UpdateVideoAsync(id,Name, LinkFile, Description);
            return ConvertVideoToDomain(links);
        }

        public async Task<List<VideoDomain>> GetAll()
        {
            var getAll = await _videoRepository.GetAll();
            return ConvertVideoToList(getAll);
        }

        public async Task<VideoDomain> GetById(int id)
        {
            var getById = await _videoRepository.GetById(id);
            return ConvertVideoToDomain(getById);
        }
    }
}
