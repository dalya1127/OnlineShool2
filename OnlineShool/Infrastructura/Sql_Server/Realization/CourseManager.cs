using Microsoft.EntityFrameworkCore;

using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Infrastructura.Sql_Server.Realization
{
    public class CourseManager : ICourseRepository
    {

        public readonly IDbContextFactory<ApplicationDbContext> _factory;
        public CourseManager(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<Course> CreateAsync(string Name, string? Description = null, string? LinkPic = null)
        {
            var _context = _factory.CreateDbContext();
            Course newCourse = new Course()
            {
                Name = Name,
                Description = Description,
                LinkPic = LinkPic
            };
            await _context.Courses.AddAsync(newCourse);
            await _context.SaveChangesAsync();
            return newCourse;
        }

        public async Task DeleteAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Courses.FindAsync(id);
            if (result == null)
            {
                return;
            }
            _context.Courses.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Course>> GetAllAsync()
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Courses.ToListAsync();
            return result;
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Courses.FindAsync(id);
            return result;

        }

        public async Task<Course> UpdateAsync(int id,string? Name = null, string? Description = null, string? LinkPic = null)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Courses.FindAsync(id);
            if (result == null)
            {
                throw new Exception("Курс не найден");
            }
            if (Name != null) result.Name = Name;
            if (Description != null) result.Description = Description;
            if (LinkPic != null) result.LinkPic = LinkPic;
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
