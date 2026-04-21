using Microsoft.EntityFrameworkCore;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server.Models;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShool.Infrastructura.Sql_Server.Realization
{
    public class VideoManager : IVideo
    {

        public readonly IDbContextFactory<ApplicationDbContext> _factory;
        public VideoManager(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }


        public async Task<Video> CreateVideoAsync(string Name, string? LinkFile = null, string? Description = null)
        {
            var _context = _factory.CreateDbContext();
            Video newVideo = new Video()
            {
                Name = Name,
                LinkFile = LinkFile,
                Description = Description

            };
            await _context.Videos.AddAsync(newVideo);
            await _context.SaveChangesAsync();
            return newVideo;
        }

        public async Task DeleteVideoAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var removeVideo = await _context.Videos.FindAsync(id);
            if (removeVideo == null)
            {
                return;
            }
            _context.Remove(removeVideo);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Video>> GetVideosByCourse(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Videos
                .Where(x => x.Id == id)
                .ToListAsync();
            return result;
        }

        public async Task<List<Video>> GetVideosByHomeWork(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Videos
                .Where(x => x.Id == id)
                .ToListAsync();
            return result;
        }

        public async Task<List<Video>> GetVideosByLessons(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Videos
                .Where(x => x.Id == id)
                .ToListAsync();
            return result;
        }

        public async Task<Video> UpdateVideoAsync(int id,string? Name = null, string? LinkFile = null, string? Description = null)
        {
            var _context = _factory.CreateDbContext();
            var updateVideo = await _context.Videos.FindAsync(id);
            if (updateVideo == null)
            {
                throw new Exception("Видео не найдено");
            }
            if (Name!=null) updateVideo.Name = Name;
            if(Description!=null) updateVideo.Description = Description;
            if (LinkFile!= null) updateVideo.LinkFile = LinkFile;
            await _context.SaveChangesAsync();
            return updateVideo;
        }
    }
}
