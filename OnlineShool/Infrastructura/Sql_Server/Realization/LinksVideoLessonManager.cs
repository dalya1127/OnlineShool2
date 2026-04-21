using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Infrastructura.Sql_Server.Realization
{
    public class LinksVideoLessonManager : ILinksVideoLesson
    {
        public readonly IDbContextFactory<ApplicationDbContext> _factory;
        public LinksVideoLessonManager(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }
        public async Task<LinksVideoLesson> CreateLinksVideoLessonAsync(int IdLessons, int IdVideos)
        {
            var _context = _factory.CreateDbContext();
            LinksVideoLesson newLinks = new LinksVideoLesson()
            {
                IdLessons = IdLessons,
                IdVideos = IdVideos

            };
            await _context.AddAsync(newLinks);
            await _context.SaveChangesAsync();
            return newLinks;
        }

        public async Task DeleteLinksVideoLessonAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var removeLink = await _context.LinksVideoLessons.FindAsync(id);
            if(removeLink == null) { return; }
            _context.Remove(removeLink);
            await _context.SaveChangesAsync();

        }

        public async Task<List<LinksVideoLesson>> GetLinksVideoLessonByLesson(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.LinksVideoLessons
                .Where(x => x.IdLessons == id)
                .ToListAsync();
            return result;


        }

        public async Task<List<LinksVideoLesson>> GetLinksVideoLessonByVideo(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.LinksVideoLessons
                .Where(x=>x.IdVideos == id)
                .ToListAsync();
            return result;
        }

        public async Task<LinksVideoLesson> UpdateLinksVideoLessonAsync(int id, int? IdVideos = null, int? IdLessons = null)
        {
            var _context = _factory.CreateDbContext();
            var updateLink = await  _context.LinksVideoLessons.FindAsync(id);
            if (updateLink == null)
            {
                throw new Exception("Связь не найдена");
            }
            if (IdLessons != null) updateLink.IdLessons = (int)IdLessons;
            if (IdVideos!= null) updateLink.IdVideos = (int)IdVideos;
            await _context.SaveChangesAsync();
            return updateLink;
        }
    }
}
