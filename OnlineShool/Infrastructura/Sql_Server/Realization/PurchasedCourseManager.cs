using Microsoft.EntityFrameworkCore;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server.Models;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShool.Infrastructura.Sql_Server.Realization
{
    public class PurchasedCourseManager : IPurchasedCourse
    {
        public readonly IDbContextFactory<ApplicationDbContext> _factory;
        public PurchasedCourseManager(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }


        public async Task<PurchasedCourse> CreatePurchasedAsync(int IdUser, int IdCourse)
        {
            var _context = _factory.CreateDbContext();
            PurchasedCourse newPurchasedCourse = new PurchasedCourse()
            {
                Id = IdUser,
                IdCourses = IdCourse,        
            };
            await _context.PurchasedCourses.AddAsync(newPurchasedCourse);
            await _context.SaveChangesAsync();
            return newPurchasedCourse;
        }

        public async Task DeletePurchasedAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var removePurchased = await _context.PurchasedCourses.FindAsync(id);
            if (removePurchased == null) { return; }
            _context.Remove(removePurchased);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PurchasedCourse>> GetPurchasedCourseByUser(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.PurchasedCourses
                .Where(x => x.IdUser == id)
                .ToListAsync();
            return result;
        }

        public async Task<PurchasedCourse> UpdatePurchasedAsync(int id,int? IdUser = null, int? IdCourse = null)
        {
            var _context = _factory.CreateDbContext();
            var updatePurchased = await _context.PurchasedCourses.FindAsync(id);
            if (updatePurchased == null)
            {
                throw new Exception("Курс не найден");
            }
            if (IdUser != null) updatePurchased.IdUser = (int)IdUser;
            if (IdCourse != null) updatePurchased.IdCourses = (int)IdCourse;
            await _context.SaveChangesAsync();
            return updatePurchased;
        }
    }
}
