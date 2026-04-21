using Microsoft.EntityFrameworkCore;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Infrastructura.Sql_Server.Realization
{
    public class ImplementingHomeworkManager : IImplementingHomeWork
    {

        public readonly IDbContextFactory<ApplicationDbContext> _factory;
        public ImplementingHomeworkManager(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<ImplementingHomeWork> CreateAsync(int IdUser, int IdHomeWork, int IdStatusHomeWork, string? LinkFile = null, int? Score = null)
        {
            var _context = _factory.CreateDbContext();
            ImplementingHomeWork newImplementing = new ImplementingHomeWork();
            {
                newImplementing.IdUser = IdUser;
                newImplementing.LinkFile = LinkFile;
                newImplementing.Score = Score;
                newImplementing.IdStatusHomeWork = IdStatusHomeWork;
                newImplementing.IdHomeWork = IdHomeWork;
            };
            await _context.ImplementingHomeWorks.AddAsync(newImplementing); 
            await _context.SaveChangesAsync();
            return newImplementing;
        }

        public async Task DeleteImplementingHW(int id)
        {
            var _context = _factory.CreateDbContext();
            var removeImplem = await _context.ImplementingHomeWorks.FindAsync(id);
            if (removeImplem == null) { return; }
            _context.Remove(removeImplem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ImplementingHomeWork>> GetImplementingHomeworkByHomeworkAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.ImplementingHomeWorks
                .Where(x => x.IdHomeWork == id)
                .ToListAsync();
            return result;
        }

        public async Task<List<ImplementingHomeWork>> GetImplementingHomeworkByUserAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.ImplementingHomeWorks
                .Where(x => x.IdUser == id)
                .ToListAsync();
            return result;
        }

        public async Task<ImplementingHomeWork> UpdateAsync(int id ,int? IdUser = null, int? IdHomeWork = null, int? IdStatusHomeWork = null, string? LinkFile = null, int? Score = null)
        {
            var _context = _factory.CreateDbContext();
            var updateImplem = await _context.ImplementingHomeWorks.FindAsync(id);
            if (updateImplem == null)
            {
                throw new Exception("Реализация не найдена");
            }
            if (IdUser != null) updateImplem.IdUser = (int)IdUser;
            if (IdHomeWork != null) updateImplem.IdHomeWork = (int)IdHomeWork;
            if (LinkFile != null) updateImplem.LinkFile = (string)LinkFile;
            if (IdStatusHomeWork !=null) updateImplem.IdStatusHomeWork = (int)IdStatusHomeWork;
            if (Score!=null) updateImplem.Score = (int)Score;
            await _context.SaveChangesAsync();
            return updateImplem;
        }
    }
}
