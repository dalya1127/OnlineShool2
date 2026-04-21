using Microsoft.EntityFrameworkCore;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server.Models;
using System.Collections.Immutable;

namespace OnlineShool.Infrastructura.Sql_Server.Realization
{
    public class ImplementingLessonManager : IImplementingLesson
    {

        public readonly IDbContextFactory<ApplicationDbContext> _factory;
        public ImplementingLessonManager(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }
        public async Task<ImplementingLesson> CreateImplementingLessonAsync(int IdUser, int IdLessons, int IdStatusLessons, string? Description = null)
        {
            var _context = _factory.CreateDbContext();
            ImplementingLesson newImplem = new ImplementingLesson()
            {
                IdUsers = IdUser,
                IdLessons = IdLessons,
                IdStatusLessons = IdStatusLessons,
                Description = Description

            };
            await _context.ImplementingLessons.AddAsync(newImplem);
            await _context.SaveChangesAsync();
            return newImplem;
        }

        public async Task DeleteImplementingLesson(int id)
        {
            var _context = _factory.CreateDbContext();
            var removeImplem = await _context.ImplementingLessons.FindAsync(id);
            if (removeImplem == null) { return; }
            _context.Remove(removeImplem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ImplementingLesson>> GetImplementingLessonByLessons(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.ImplementingLessons
                .Where(x => x.IdLessons == id)
                .ToListAsync();
            return result;
        }

        public async Task<List<ImplementingLesson>> GetImplementingLessonByUser(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.ImplementingLessons
                .Where( x => x.IdUsers == id)
                .ToListAsync();
            return result;
        }

        public async Task<ImplementingLesson> UpdateImplementingLessonAsync(int? IdUser = null, int? IdLessons = null, int? IdStatusLessons = null, string? Description = null)
        {
            var _context = _factory.CreateDbContext();
            var updateImplem = await _context.ImplementingLessons.FindAsync(IdUser);
            if (updateImplem == null)
            {
                throw new Exception("Реализация не найдена");
            }
            if (IdUser!=null) updateImplem.IdUsers = (int) IdUser;
            if (IdLessons!=null ) updateImplem.IdLessons = (int) IdLessons;
            if (IdStatusLessons!=null) updateImplem.IdStatusLessons = (int) IdStatusLessons;
            if (Description!=null) updateImplem.Description = (string) Description;
            await _context.SaveChangesAsync();
            return updateImplem;
        }
    }
}
