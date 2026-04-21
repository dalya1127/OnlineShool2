
namespace OnlineShool.Domain;
public interface ILessonDomain
{
    Task<LessonDomain?> GetByIdAsync(int id);
    Task<IReadOnlyList<LessonDomain>> GetAllAsync();
    Task<IReadOnlyList<LessonDomain>> GetByCourseIdAsync(int courseId);

    Task<LessonDomain> CreateLessonAsync(
        int IdCourses,
        string Name,
        int NumberLessons,
        string? LinkFile = null,
        string? LinkPic = null,
        string? Description = null
        );

    Task<LessonDomain> UpdateLessonAsync(
        int id,
        int? IdCourses = null,
        string? Name = null,
        int? NumberLessons = null,
        string? LinkFile = null,
        string? LinkPic = null,
        string? Description = null
        );
    Task<List<ImplementingLessonDomain>> GetImplementingLessonByLessons(int id);
    Task<List<ImplementingLessonDomain>> GetImplementingLessonByUser(int id);
    Task<ImplementingLessonDomain> CreateImplementingLessonAsync(
        int IdUser,
        int IdLessons,
        int IdStatusLessons,
        string? Description = null
        );
    Task<ImplementingLessonDomain> UpdateImplementingLessonAsync(
        int id,
        int? IdUser = null,
        int? IdLessons = null,
        int? IdStatusLessons = null,
        string? Description = null
        );

    Task<List<LinksLessonsHomeWorkDomain>> GetLinksLessonsHomeWorkByLesson(int id);
    Task<List<LinksLessonsHomeWorkDomain>> GetLinksLessonsHomeWorkByHomeWork(int id);
    Task<LinksLessonsHomeWorkDomain> CreateLinksLessonsHomeWorkAsync(
        int IdHomework,
        int IdLessons
        );
    Task<LinksLessonsHomeWorkDomain> UpdateLinksLessonsHomeWorkAsync(
        int id,
        int? IdHomework = null,
        int? IdLessons = null
        );



    Task<List<StatusLessonDomain>> GetStatusLessonsByLessons(int id);
    Task<List<StatusLessonDomain>> GetStatusLessonsByUser(int id);

    Task<StatusLessonDomain> CreateStatusLessonsAsync(
        string Name,
        string? Description
        );
    Task<StatusLessonDomain> UpdateStatusLessonsAsync(
        int id,
        string? Name = null,
        string? Description = null
        );
    Task DeleteLessonAsync(int id);
    Task DeleteImplementingLessonAsync(int id);
    Task DeleteStatusLessonsAsync(int id);
    Task DeleteLinksLessonsHomeWorkAsync(int id);
}
