using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server.Models;
using System.Net.WebSockets;

namespace OnlineShool.Infrastructura.Sql_Server.Realization
{
    public class LinksLessonsHomeworkManager : ILinksLessonsHomeWork
    {
        public readonly IDbContextFactory<ApplicationDbContext> _factory;
        public LinksLessonsHomeworkManager(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }
        public async Task<LinksLessonsHomeWork> CreateLinksLessonsHomeWorkAsync(int IdHomework, int IdLessons)
        {
            var _context = _factory.CreateDbContext();
            LinksLessonsHomeWork newLinsLessonHomeWork = new LinksLessonsHomeWork()
            {
                IdHomework = IdHomework,
                IdLessons = IdLessons,

            };
            await _context.AddAsync(newLinsLessonHomeWork);
            await _context.SaveChangesAsync();
            return newLinsLessonHomeWork;
        }

        public async Task DeleteLinksLessonsHomeWorkAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var removeLink = await  _context.LinksLessonsHomeWorks.FindAsync(id);
            if (removeLink == null) { return; }
            _context.Remove(removeLink);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LinksLessonsHomeWork>> GetLinksLessonsHomeWorkByHomeWork(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.LinksLessonsHomeWorks
                .Where(x => x.IdHomework == id )
                .ToListAsync();
            return result;
        }

        public async Task<List<LinksLessonsHomeWork>> GetLinksLessonsHomeWorkByLesson(int id)
        {
            var _context = _factory.CreateDbContext();
            var result =  await _context.LinksLessonsHomeWorks
                .Where(x=>x.IdLessons == id)
                .ToListAsync();
            return result;

        }

        public async Task<LinksLessonsHomeWork> UpdateLinksLessonsHomeWorkAsync(
            int id ,
            int? IdHomework = null,
            int? IdLessons = null)
        {
            var _context = _factory.CreateDbContext();
            var updateLink = await _context.LinksLessonsHomeWorks.FindAsync(id);
            if (updateLink == null)
            {
                throw new Exception("Связь не найдена");
            }
            if (IdHomework != null) updateLink.IdHomework = (int)IdHomework;
            if (IdLessons != null) updateLink.IdLessons = (int)IdLessons;
            await _context.SaveChangesAsync();
            return updateLink;
        }
    }
}
