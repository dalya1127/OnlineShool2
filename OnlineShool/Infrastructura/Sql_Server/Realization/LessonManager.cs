using Microsoft.EntityFrameworkCore;
using OnlineShool.Infrastructura.Sql_Server.Models;


namespace OnlineShool.Infrastructura.Sql_Server.Realization
{
    public class LessonManager : ILessonRepository
    {
        public readonly IDbContextFactory<ApplicationDbContext> _factory;
        public LessonManager(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }


        public async Task<Lesson> CreateLessonAsync(int IdCourses, string Name, int NumberLessons, string? LinkFile = null, string? LinkPic = null, string? Description = null)
        {
            var _context = _factory.CreateDbContext();
            Lesson newLesson = new Lesson()
            {
                IdCourses = IdCourses,
                Name = Name,
                NumberLessons = NumberLessons,
                LinkFile = LinkFile,
                LinkPic = LinkPic,
                Description = Description

            };
            
            await _context.Lessons.AddAsync(newLesson);
            await _context.SaveChangesAsync();
            return newLesson;
        }

        public async Task DeleteLessonAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var removeLesson = await _context.Lessons.FindAsync(id);
            if (removeLesson == null) 
            {
                return;
            }
            _context.Lessons.Remove(removeLesson);
            await _context.SaveChangesAsync();

        }

        public async Task<IReadOnlyList<Lesson>> GetAllAsync()
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Lessons.ToListAsync();
            return result;
        }

        public async Task<IReadOnlyList<Lesson>> GetByCourseIdAsync(int courseId)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Lessons
                .Where( x => x.IdCourses == courseId)
                .ToListAsync();
            return result;

        }

        public async Task<Lesson?> GetByIdAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Lessons.FindAsync(id);
            return result;
        }

        public async Task<Lesson> UpdateLessonAsync(int id, int? IdCourses = null, string? Name = null, int? NumberLessons = null, string? LinkFile = null, string? LinkPic = null, string? Description = null)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Lessons.FindAsync(id);
            if (result == null)
            {
                throw new Exception("Урок не найден");
            }
            if (Name!= null)
            {
                result.Name = Name;               
            }
            if (IdCourses != null) 
            {
                result.IdCourses = (int)IdCourses;
            }
            if (NumberLessons != null)
            {
                result.NumberLessons = (int)NumberLessons;
            }
            if (LinkFile != null) { 
                result.LinkFile = LinkFile;
            }
            if (LinkPic != null) {
            result.LinkPic = LinkPic;
            }
            if(Description != null)
            {
                result.Description = Description; 
            }
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
