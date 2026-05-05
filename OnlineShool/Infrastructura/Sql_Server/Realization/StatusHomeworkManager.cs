using Microsoft.EntityFrameworkCore;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server.Models;


namespace OnlineShool.Infrastructura.Sql_Server.Realization
{
    public class StatusHomeworkManager : IStatusHomeWork
    {

        public readonly IDbContextFactory<ApplicationDbContext> _factory;
        public StatusHomeworkManager(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<StatusHomeWork> CreateStatusHomeWorkAsync(string Name, string? Description)
        {
            var _context = _factory.CreateDbContext();
            StatusHomeWork newStatusHomeWork = new StatusHomeWork()
            {

            };
            await _context.StatusHomeWorks.AddAsync(newStatusHomeWork);
            await _context.SaveChangesAsync();
            return newStatusHomeWork;
        }

        public async Task DeleteStatusHomeWork(int id)
        {
            var _context = _factory.CreateDbContext();
            var removeStatusHomeWork = await _context.StatusHomeWorks.FindAsync(id);
            if (removeStatusHomeWork == null)
            {
                return;
            }
            _context.Remove(removeStatusHomeWork);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StatusHomeWork>> GetStatusHomeWorkByHomeWork(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.StatusHomeWorks
                .Where(x => x.Id == id)
                .ToListAsync();
            return result;

        }

        public async Task<List<StatusHomeWork>> GetStatusHomeWorkByLessons(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.StatusHomeWorks
                .Where(x => x.Id == id)
                .ToListAsync();
            return result;
        }

        public async Task<List<StatusHomeWork>> GetStatusHomeWorkByUser(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.StatusHomeWorks
                .Where(x => x.Id == id)
                .ToListAsync();
            return result;
        }

        public async Task<StatusHomeWork> UpdateStatusHomeWorkAsync(int id,string? Name = null, string? Description = null)
        {
            var _context = _factory.CreateDbContext();
            var updateStatusHomeWork = await _context.StatusHomeWorks.FindAsync(id);
            if (updateStatusHomeWork == null)
            {
                throw new Exception("Статус не найден");
            }
            if (Name != null) updateStatusHomeWork.Name = Name;
            if (Description!=null) updateStatusHomeWork.Description = Description;
            await _context.SaveChangesAsync();
            return updateStatusHomeWork;

        }
    }
}
