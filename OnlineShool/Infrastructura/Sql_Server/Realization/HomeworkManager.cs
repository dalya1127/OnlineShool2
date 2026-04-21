using Microsoft.EntityFrameworkCore;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Infrastructura.Sql_Server.Realization
{
    public class HomeworkManager : IHomeWork
    {
        public readonly IDbContextFactory<ApplicationDbContext> _factory;
        public HomeworkManager(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }


        public async Task<HomeWork> CreateAsync(string Name, string? Description, string? LinkFile = null)
        {
            var _context = _factory.CreateDbContext();
            HomeWork homeWork = new HomeWork()
            {
                Name = Name,
                Description = Description,
                LinkFile = LinkFile
            };
            await _context.HomeWorks.AddAsync(homeWork);
            await _context.SaveChangesAsync();
            return homeWork;
            
        }

        public async Task DeleteAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.HomeWorks.Include(x => x.ImplementingHomeWorks).Include(x => x.LinksLessonsHomeWorks).FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) { return; }
            var implimentingHW = result.ImplementingHomeWorks;
            foreach (var elem in implimentingHW) { _context.ImplementingHomeWorks.Remove(elem); }

            var link = result.LinksLessonsHomeWorks;
            foreach (var elem in link) { _context.LinksLessonsHomeWorks.Remove(elem); }
            _context.HomeWorks.Remove(result);
            await _context.SaveChangesAsync();

        }

        public async Task<IReadOnlyList<HomeWork>> GetAllAsync()
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.HomeWorks.ToListAsync();
            return result;
        }


        public async Task<HomeWork> UpdateAsync(int Id ,string? LinkFile = null, string? Name=null, string? Description = null)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.HomeWorks.FindAsync(Id);
            if (result == null)  
            {
                throw new Exception("Домашнее задание не найдено");
            }
            if (Description != null) result.Description = Description;
            if (Name != null) result.Name = Name;
            if (LinkFile != null) result.LinkFile = LinkFile;
            await _context.SaveChangesAsync();
            return result;
        }

    }
}

