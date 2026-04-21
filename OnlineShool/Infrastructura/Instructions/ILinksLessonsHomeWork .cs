using OnlineShool.Infrastructura.Sql_Server.Models;
namespace OnlineShool.Infrastructura.Instructions
{
    public interface ILinksLessonsHomeWork 
    {
        Task<List<LinksLessonsHomeWork>> GetLinksLessonsHomeWorkByLesson(int id);
        Task<List<LinksLessonsHomeWork>> GetLinksLessonsHomeWorkByHomeWork(int id);
        Task<LinksLessonsHomeWork> CreateLinksLessonsHomeWorkAsync(
            int IdHomework,
            int IdLessons
            );
        Task<LinksLessonsHomeWork> UpdateLinksLessonsHomeWorkAsync(
            int id,
            int? IdHomework = null,
            int? IdLessons = null
            );
        Task DeleteLinksLessonsHomeWorkAsync(int id);
    }
}
