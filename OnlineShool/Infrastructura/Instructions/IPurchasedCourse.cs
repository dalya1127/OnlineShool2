using OnlineShool.Infrastructura.Sql_Server.Models;
namespace OnlineShool.Infrastructura.Instructions
{
    public interface IPurchasedCourse
    {
        Task<List<PurchasedCourse>> GetAllAsync();
        Task<List<PurchasedCourse>> GetPurchasedCourseByUser(int id);
        Task<PurchasedCourse> CreatePurchasedAsync (
            int IdUser,
            int IdCourse
            );
        Task<PurchasedCourse> UpdatePurchasedAsync(
            int id,
            int? IdUser = null,
            int? IdCourse = null 
            );
        Task DeletePurchasedAsync(int id);
    }
}