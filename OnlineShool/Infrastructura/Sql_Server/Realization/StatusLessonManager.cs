using Microsoft.EntityFrameworkCore;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server.Models;


namespace OnlineShool.Infrastructura.Sql_Server.Realization
{
    public class StatusLessonManager : IStatusLesson
    {

        public readonly IDbContextFactory<ApplicationDbContext> _factory;
        public StatusLessonManager(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<StatusLesson> CreateStatusLessonsAsync(string Name, string? Description)
        {
            var _context = _factory.CreateDbContext();
            StatusLesson newStatusLesson = new StatusLesson()
            {
                Name = Name,
                Description = Description
            };
            await _context.StatusLessons.AddAsync(newStatusLesson);
            await _context.SaveChangesAsync();
            return newStatusLesson;
        }

        public async Task DeleteStatusLessons(int id)
        {
            var _context = _factory.CreateDbContext();
            var removeStatusLesson = await _context.StatusLessons.FindAsync(id);
            if (removeStatusLesson == null)
            {
                return;
            }
            _context.Remove(removeStatusLesson);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StatusLesson>> GetStatusLessonsByLessons(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.StatusLessons
                .Where(x => x.Id == id)
                .ToListAsync();
            return result;
        }

        public async Task<List<StatusLesson>> GetStatusLessonsByUser(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.StatusLessons
                .Where(x => x.Id == id)
                .ToListAsync();
            return result;
        }

        public async Task<StatusLesson> UpdateStatusLessonsAsync(int id,string? Name = null, string? Description = null)
        {
            var _context = _factory.CreateDbContext();
            var updateStatusLesson = await _context.StatusLessons.FindAsync(id);
            if (updateStatusLesson == null)
            {
                throw new Exception("Статус не найден");
            }
            if (Name != null) updateStatusLesson.Name = Name;
            if (Description!=null) updateStatusLesson.Description = Description;
            await _context.SaveChangesAsync();
            return updateStatusLesson;
        }
    }
}
